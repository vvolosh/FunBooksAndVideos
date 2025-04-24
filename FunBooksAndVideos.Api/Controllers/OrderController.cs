using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Core.Interfaces.Services;
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
        try
        {
            var order = Mappers.PurchaseOrderMap.MapToDomain(request);
            var context = _purchaseOrderService.Process(order);

            if (context.Errors.Any())
                return BadRequest(new { context.Errors });

            return Ok(new PurchaseResultDto
            {
                ActivatedMembership = context.ActivatedMembership,
                ShippingLabels = context.ShippingLabels,
                Errors = context.Errors
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occured.");
            return StatusCode(500, "An internal server error occured.");
        }
    }
}