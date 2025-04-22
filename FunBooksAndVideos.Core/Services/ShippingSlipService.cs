using FunBooksAndVideos.Entities.Products;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Services;

public class ShippingSlipService : IShippingSlipService
{
    private readonly ILogger<ShippingSlipService> _logger;

    public ShippingSlipService(ILogger<ShippingSlipService> logger)
    {
        _logger = logger;
    }

    public string GenerateShippingSlip(Product product, int customer)
    {
        _logger.LogInformation($"Generating shipping slip for customer {customer} to deliver {product.Name}");
        return $"Shipping slip for customer {customer} to deliver {product.Name}";
    }
}