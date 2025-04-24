using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;
using FunBooksAndVideos.Core.Interfaces.Handlers;
using FunBooksAndVideos.Core.Interfaces.Services;

namespace FunBooksAndVideos.Core.Handlers;

public class BookHandler : IProductHandler
{
    private readonly IShippingSlipService _shippingSlipService;

    public BookHandler(IShippingSlipService shippingSlipService)
    {
        _shippingSlipService = shippingSlipService;
    }

    public bool CanHandle(Product product) => product is Book;
    public void Handle(Product product, PurchaseContext context)
    {
        var shippingSlip = _shippingSlipService.GenerateShippingSlip(product, context.CustomerId);
        context.ShippingLabels.Add(shippingSlip);
    }
}