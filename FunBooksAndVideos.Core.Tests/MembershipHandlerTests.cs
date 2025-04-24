using FunBooksAndVideos.Core.Entities;
using FunBooksAndVideos.Core.Entities.Products;
using FunBooksAndVideos.Core.Enums;
using FunBooksAndVideos.Core.Handlers;
using FunBooksAndVideos.Core.Interfaces.Services;
using Moq;

namespace FunBooksAndVideos.Core.Tests;

public class MembershipHandlerTests
{
    private readonly Mock<ICustomerMembershipService> _membershipServiceMock = new();

    [Fact]
    public void Handle_WhenMembershipIsActivated_ShouldRecordActivatedMembership()
    {
        //Arrange
        var handler = new MembershipHandler(_membershipServiceMock.Object);
        var product = new Membership { MembershipType = MembershipType.BookClub };
        var context = new PurchaseContext { CustomerId = 123 };

        //Act
        handler.Handle(product, context);

        //Assert
        _membershipServiceMock.Verify(
            s => s.ActivateMembership(context.CustomerId, MembershipType.BookClub), Times.Once);
        Assert.Equal(MembershipType.BookClub, context.ActivatedMembership);

    }

    [Fact]
    public void Handle_WhenMultipleMemberships_ShouldRecordError()
    {
        //Arrange
        var handler = new MembershipHandler(_membershipServiceMock.Object);
        var product = new Membership { MembershipType = MembershipType.VideoClub };
        var context = new PurchaseContext { CustomerId = 123, ActivatedMembership = MembershipType.BookClub };

        //Act
        handler.Handle(product, context);

        //Assert
        Assert.Single(context.Errors);
        Assert.Equal("Multiple membership requests detected.", context.Errors.First());
    }
}