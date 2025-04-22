namespace FunBooksAndVideos.Api.Models;

public class PurchaseOrderDto
{
    public int PurchaseOrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal Total { get; set; }
    public List<ProductDto> Items { get; set; } = new();
}