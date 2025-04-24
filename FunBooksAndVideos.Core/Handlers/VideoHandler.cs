using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;
using FunBooksAndVideos.Core.Interfaces.Handlers;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Core.Handlers;

public class VideoHandler(ILogger<VideoHandler> logger) : IProductHandler
{
    public bool CanHandle(Product product) => product is Video;

    public void Handle(Product product, PurchaseContext context)
    {
         logger.LogInformation($"Notifying customer {context.CustomerId} about the video: {product.Name}.");
    }
}