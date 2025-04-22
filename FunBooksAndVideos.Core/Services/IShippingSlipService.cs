using FunBooksAndVideos.Entities.Products;

namespace FunBooksAndVideos.Services;

public interface IShippingSlipService
{
    string GenerateShippingSlip(Product product, int customer);
}