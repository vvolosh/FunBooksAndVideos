using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Entities.Products;

public class Video : Product
{
    public override ProductType ProductType => ProductType.Video;
}