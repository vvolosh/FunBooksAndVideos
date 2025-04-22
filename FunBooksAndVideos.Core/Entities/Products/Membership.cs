using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Entities.Products;

public class Membership : Product
{
    public override ProductType ProductType => ProductType.Membership;
    public MembershipType MembershipType { get; set; }
}