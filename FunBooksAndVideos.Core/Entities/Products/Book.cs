using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Entities.Products;

public class Book : Product
{
    public override ProductType ProductType => ProductType.Book;
}