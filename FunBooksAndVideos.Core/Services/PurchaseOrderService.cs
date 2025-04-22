using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Handlers;

namespace FunBooksAndVideos.Services;

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
            handler?.Handle(item, context);
        }
        
        return context;
    }
}
