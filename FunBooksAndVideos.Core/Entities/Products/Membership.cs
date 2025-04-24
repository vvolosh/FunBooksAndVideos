using FunBooksAndVideos.Core.Enums;

namespace FunBooksAndVideos.Core.Entities.Products;

public class Membership : Product
{
    public override ProductType ProductType => ProductType.Membership;
    public MembershipType MembershipType { get; set; }
}