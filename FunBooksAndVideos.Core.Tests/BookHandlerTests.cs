using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;
using FunBooksAndVideos.Core.Handlers;
using FunBooksAndVideos.Core.Interfaces.Services;
using Moq;

namespace FunBooksAndVideos.Core.Tests;

public class BookHandlerTests
{
    private readonly Mock<IShippingSlipService> _shippingSlipServiceMock = new();
    
    [Fact]
    public void Handle_ShouldGenerateShippingSlip()
    {
        //Arrange
        var handler = new BookHandler(_shippingSlipServiceMock.Object);
        var product = new Book { Name = "TestBook" };
        var context = new PurchaseContext { CustomerId = 123 };
        _shippingSlipServiceMock
            .Setup(s => s.GenerateShippingSlip(product, context.CustomerId))
            .Returns("Shipping slip generated");

        //Act
        handler.Handle(product, context);

        //Assert
        Assert.Single(context.ShippingLabels);
        Assert.Equal("Shipping slip generated", context.ShippingLabels.First());
    }
}