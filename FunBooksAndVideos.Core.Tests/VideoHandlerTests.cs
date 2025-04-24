using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;
using FunBooksAndVideos.Core.Handlers;
using Moq;
using Microsoft.Extensions.Logging;

namespace FunBooksAndVideos.Core.Tests;

public class VideoHandlerTests
{
    private readonly Mock<ILogger<VideoHandler>> _loggerMock = new();

    [Fact]
    public void Handle_ShouldLogNotification()
    {
        //Arrnge
        var handler = new VideoHandler(_loggerMock.Object);
        var product = new Video { Name = "Test Video" };
        var context = new PurchaseContext { CustomerId = 123 };

        //Act
        handler.Handle(product, context);

        //Assert
        _loggerMock.Verify(
            x => x.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Information),
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, _) => 
                    state.ToString()!.Contains("Notifying customer 123 about")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.Once
        );
    }
}