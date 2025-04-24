using FunBooksAndVideos.Core.Entities;

namespace FunBooksAndVideos.Core.Interfaces.Services;

public interface IPurchaseOrderService
{
    PurchaseContext Process(PurchaseOrder order);
}