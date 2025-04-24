using FunBooksAndVideos.Core.Entities.Products;

namespace FunBooksAndVideos.Core.Interfaces.Services;

public interface IShippingSlipService
{
    string GenerateShippingSlip(Product product, int customer);
}