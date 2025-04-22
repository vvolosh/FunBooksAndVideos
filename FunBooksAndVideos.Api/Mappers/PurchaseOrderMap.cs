using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Entities.Products;
using FunBooksAndVideos.Enums;

namespace FunBooksAndVideos.Api.Mappers;

public static class PurchaseOrderMap
{
    public static PurchaseOrder MapToDomain(PurchaseOrderDto dto)
    {
        var items = dto.Items.Select(item =>
        {
            Product product = item.ProductType switch
            {
                ProductType.Book => new Book { Name = item.Name, Price = item.Price },
                ProductType.Video => new Video { Name = item.Name, Price = item.Price },
                ProductType.Membership => new Membership
                {
                    Name = item.Name,
                    Price = item.Price,
                    MembershipType = item.MembershipType ??
                                     throw new ArgumentException("MembershipType is required")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(item.ProductType), 
                    $"Unsupported product type: {item.ProductType}")
            };

            return product;
        }).ToList();

        return new PurchaseOrder
        {
            PurchaseOrderId = dto.PurchaseOrderId,
            CustomerId = dto.CustomerId,
            Items = items
        };
    }
}