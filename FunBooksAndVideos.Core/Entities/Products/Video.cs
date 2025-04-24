using FunBooksAndVideos.Core.Enums;

namespace FunBooksAndVideos.Core.Entities.Products;

public class Video : Product
{
    public override ProductType ProductType => ProductType.Video;
}