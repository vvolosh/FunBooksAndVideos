using FunBooksAndVideos.Core.Enums;

namespace FunBooksAndVideos.Core.Entities.Products;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public virtual ProductType ProductType { get; set; }
}