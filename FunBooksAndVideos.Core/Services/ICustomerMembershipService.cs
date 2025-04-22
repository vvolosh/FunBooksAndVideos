using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Services;

public interface ICustomerMembershipService
{
    void ActivateMembership(int customer, MembershipType membershipType);
}