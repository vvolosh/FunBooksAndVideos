using FunBooksAndVideos.Core.Enums;

namespace FunBooksAndVideos.Core.Entities.Products;

public class Book : Product
{
    public override ProductType ProductType => ProductType.Book;
}