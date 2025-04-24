using FunBooksAndVideos.Core.Enums;

namespace FunBooksAndVideos.Core.Interfaces.Services;

public interface ICustomerMembershipService
{
    void ActivateMembership(int customer, MembershipType membershipType);
}