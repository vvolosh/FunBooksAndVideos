using FunBooksAndVideos.Core.Enums;

namespace FunBooksAndVideos.Core.Entities;

public class PurchaseContext
{
    public int CustomerId { get; set; }
    public MembershipType? ActivatedMembership { get; set; }
    public List<string> ShippingLabels { get; set; } = new();
    public List<string> Errors { get; set; } = new();
}