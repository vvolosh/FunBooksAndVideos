using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Interfaces.Handlers;
using FunBooksAndVideos.Core.Interfaces.Services;

namespace FunBooksAndVideos.Core.Services;

public class PurchaseOrderService : IPurchaseOrderService
{
    private readonly IEnumerable<IProductHandler> _handlers;
    public PurchaseOrderService(IEnumerable<IProductHandler> handlers)
    {
        _handlers = handlers;
    }

    public PurchaseContext Process(PurchaseOrder order)
    {
        var context = new PurchaseContext { CustomerId = order.CustomerId };
        foreach (var item in order.Items)
        {
            var handler = _handlers.FirstOrDefault(h => h.CanHandle(item));
            if (handler is null)
            {
                context.Errors.Add($"No handler found for product type {item.ProductType}");
                continue;
            }

            handler?.Handle(item, context);
        }
        
        return context;
    }
}
