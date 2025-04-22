using FunBooksAndVideos.Entities;

namespace FunBooksAndVideos.Services;

public interface IPurchaseOrderService
{
    PurchaseContext Process(PurchaseOrder order);
}