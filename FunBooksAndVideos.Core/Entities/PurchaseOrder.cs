using FunBooksAndVideos.Core.Entities.Products;

namespace FunBooksAndVideos.Core.Entities;

public class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }
    public int CustomerId { get; set; }
    public List<Product> Items { get; set; } = new();
    public decimal Total { get; set; }
}