using FunBooksAndVideos.Core.Enums;
using FunBooksAndVideos.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Core.Services;

public class CustomerMembershipService : ICustomerMembershipService
{
    private readonly ILogger<CustomerMembershipService> _logger;

    public CustomerMembershipService(ILogger<CustomerMembershipService> logger)
    {
        _logger = logger;
    }

    public void ActivateMembership(int customer, MembershipType membershipType)
    {
        _logger.LogInformation($"Activating {membershipType.ToString()} membership for customer {customer}");
    }
}