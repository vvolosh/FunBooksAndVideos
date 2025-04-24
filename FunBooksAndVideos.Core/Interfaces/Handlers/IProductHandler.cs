using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;

namespace FunBooksAndVideos.Core.Interfaces.Handlers;

public interface IProductHandler
{
    bool CanHandle(Product product);
    void Handle(Product product, PurchaseContext context);
}