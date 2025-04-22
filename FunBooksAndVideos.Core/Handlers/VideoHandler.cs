using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Entities.Products;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Handlers;

public class VideoHandler(ILogger<VideoHandler> logger) : IProductHandler
{
    public bool CanHandle(Product product) => product is Video;

    public void Handle(Product product, PurchaseContext context)
    {
         logger.LogInformation($"Notifying customer {context.CustomerId} about the video: {product.Name}.");
    }
}