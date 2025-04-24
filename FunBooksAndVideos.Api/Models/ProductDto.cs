using FunBooksAndVideos.Core.Enums;

namespace FunBooksAndVideos.Api.Models;

public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductType ProductType { get; set; }
    public MembershipType? MembershipType { get; set; }
}