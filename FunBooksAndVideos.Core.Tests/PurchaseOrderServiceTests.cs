using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;
using FunBooksAndVideos.Core.Interfaces.Handlers;
using FunBooksAndVideos.Core.Services;
using Moq;

namespace FunBooksAndVideos.Core.Tests;

public class PurchaseOrderServiceTests
{
    [Fact]
    public void Process_WhenHandlerExists_ShouldInvokeHandler()
    {
        //Arrange
        var handlersMock = new Mock<IProductHandler>();
        handlersMock.Setup(
            h => h.CanHandle(It.IsAny<Product>())).Returns(true);
        var service = new PurchaseOrderService(new[] { handlersMock.Object });
        var order = new PurchaseOrder
        {
            CustomerId = 1,
            Items = [new Book()]
        };
        
        //Act
        service.Process(order);
        
        //Assert
        handlersMock.Verify(
            h => h.Handle(
                It.IsAny<Product>(),
                It.IsAny<PurchaseContext>()),
            Times.Once);
    }

    [Fact]
    public void Process_WhenHandlerNotFound_ShouldRecordError()
    {
        //Arrange
        var service = new PurchaseOrderService(new List<IProductHandler>());
        var order = new PurchaseOrder
        {
            CustomerId = 1,
            Items = [new Book { Name = "TestBook" }]
        };

        //Act
        var context = service.Process(order);

        //Assert
        Assert.Single(context.Errors);
        Assert.Contains("No handler found", context.Errors.First());
    }
}