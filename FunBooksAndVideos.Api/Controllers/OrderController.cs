using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseOrderController : ControllerBase
{
    private readonly IPurchaseOrderService _purchaseOrderService;
    private readonly ILogger<PurchaseOrderController> _logger;

    public PurchaseOrderController(
        IPurchaseOrderService orderService, 
        ILogger<PurchaseOrderController> logger)
    {
        _purchaseOrderService = orderService;
        _logger = logger;
    }

    [HttpPost]
    public ActionResult<PurchaseResultDto> Process([FromBody] PurchaseOrderDto request)
    {
        var order = Mappers.PurchaseOrderMap.MapToDomain(request);
        var context = _purchaseOrderService.Process(order);
        return new PurchaseResultDto
        {
            ActivatedMembership = context.ActivatedMembership,
            ShippingLabels = context.ShippingLabels,
            Errors = context.Errors
        };
    }
}