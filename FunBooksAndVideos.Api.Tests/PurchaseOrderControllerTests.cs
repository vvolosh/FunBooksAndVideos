using Moq;
using FunBooksAndVideos.Api.Controllers;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Tests;

public class PurchaseOrderControllerTests
{
    private readonly Mock<IPurchaseOrderService> _purchaseOrderServiceMock = new();
    private readonly Mock<ILogger<PurchaseOrderController>> _loggerMock = new();

    [Fact]
    public void Process_WhenSuccessful_ShouldReturnOk()
    {
        //Arrange
        _purchaseOrderServiceMock.Setup(
                s => s.Process(It.IsAny<PurchaseOrder>()))
            .Returns(new PurchaseContext());
        var controller = new PurchaseOrderController(_purchaseOrderServiceMock.Object, _loggerMock.Object);

        //Act
        var result = controller.Process(new PurchaseOrderDto());

        //Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, actionResult.StatusCode);
    }

    [Fact]
    public void Process_WhenErrorsOccur_ShouldReturnBadRequest()
    {
        //Arrange
        _purchaseOrderServiceMock.Setup(
                s => s.Process(It.IsAny<PurchaseOrder>()))
            .Returns(new PurchaseContext { Errors = ["Error occurred"] });
        var controller = new PurchaseOrderController(_purchaseOrderServiceMock.Object, _loggerMock.Object);

        //Act
        var result = controller.Process(new PurchaseOrderDto());

        //Assert
        var actionResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal(400, actionResult.StatusCode);
    }
}