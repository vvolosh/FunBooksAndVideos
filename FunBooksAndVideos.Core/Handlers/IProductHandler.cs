using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Entities.Products;

namespace FunBooksAndVideos.Handlers;

public interface IProductHandler
{
    bool CanHandle(Product product);
    void Handle(Product product, PurchaseContext context);
}