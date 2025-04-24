using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;
using FunBooksAndVideos.Core.Interfaces.Handlers;
using FunBooksAndVideos.Core.Interfaces.Services;

namespace FunBooksAndVideos.Core.Handlers;

public class MembershipHandler : IProductHandler
{
    private ICustomerMembershipService _customerMembershipService;

    public MembershipHandler(ICustomerMembershipService customerMembershipService)
    {
        _customerMembershipService = customerMembershipService;
    }

    public bool CanHandle(Product product) => product is Membership;
    public void Handle(Product product, PurchaseContext context)
    {
        var membership = (Membership)product;

        if (context.ActivatedMembership is not null && context.ActivatedMembership != membership.MembershipType)
        {
            context.Errors.Add("Multiple membership requests detected.");
            return;
        }

        _customerMembershipService.ActivateMembership(context.CustomerId, membership.MembershipType);
        context.ActivatedMembership = membership.MembershipType;
    }
}