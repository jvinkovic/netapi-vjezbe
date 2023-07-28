using Microsoft.AspNetCore.Mvc;
using Moq;
using Staycation.API.Controllers;
using Staycation.Business.Interfaces;

namespace Staycation.Test;

public class AccomodationControllerTest
{
    private Mock<IAccommodationService> _serviceMock = new Mock<IAccommodationService>();

    public AccomodationControllerTest()
    { }

    [Fact]
    public async Task GetByIdAsync_NonExistingItem_NotFound()
    {
        _serviceMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);
        var controller = new AccommodationController(_serviceMock.Object);

        // Act
        var actionResult = await controller.GetById(It.IsAny<int>());

        // Assert
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }
}
