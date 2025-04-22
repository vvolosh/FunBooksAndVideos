using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Api.Models;

public class PurchaseResultDto
{
    public MembershipType? ActivatedMembership { get; set; }
    public List<string> ShippingLabels { get; set; } = new();
    public List<string> Errors { get; set; } = new();
}