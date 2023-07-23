using Staycation.Business.Services;

namespace Staycation.Test;

public class AccomodationServiceTest : IClassFixture<DbFixture>
{
    private readonly AccommodationService _service;
    private readonly DbFixture _fixture;

    public AccomodationServiceTest(DbFixture fixture)
    {
        _fixture = fixture;
        _service = new AccommodationService(fixture.Context);
    }

    [Fact]
    public async Task GetAccomodationById_WithNonExistingItem_Fail()
    {
        var accommodationId = 25;

        //Act
        var accommodation = await _service.GetByIdAsync(accommodationId);

        //Assert
        Assert.Null(accommodation);
    }

    [Fact]
    public async Task GetAccomodationById_WithExistingItem_Success()
    {
        var accommodationId = 2;
        var title = "CasaKrystal";

        //Act
        var accommodation = await _service.GetByIdAsync(accommodationId);

        //Assert
        Assert.NotNull(accommodation);
        Assert.Equal(title, accommodation.Title);
    }

    [Fact]
    public async Task GetAccommodations_WithExistingItems_ReturnsAll()
    {
        //Act
        var items = await _service.GetAllAsync();

        //Assert
        Assert.Equal(3, items.Count());
    }

    [Fact]
    public async Task CreateAccommodation_WithoutLocation_ThrowsException()
    {
        //Act
        var newAccommodation = new Business.DTO.CreateEditAccommodationDTO
        {
            Categorisation = 5,
            Description = "Test",
            FreeCancellation = true,
            ImageUrl = null,
            LocationId = 45,
            PersonCount = 1,
            Price = 1,
            Subtitle = "Test Sub",
            Title = "Test",
            Type = "Stan"
        };

        //Assert
        await Assert.ThrowsAnyAsync<Exception>(async () => await _service.CreateAsync(newAccommodation));
    }

    [Fact]
    public async Task CreateAccommodation_WithDuplicateTitle_ThrowsException()
    {
        //Act
        var newAccommodation = new Business.DTO.CreateEditAccommodationDTO
        {
            Categorisation = 5,
            Description = "Test",
            FreeCancellation = true,
            ImageUrl = null,
            LocationId = 1,
            PersonCount = 1,
            Price = 1,
            Subtitle = "Test Sub",
            Title = "CasaKrystal",
            Type = "Stan"
        };

        //Assert
        await Assert.ThrowsAnyAsync<Exception>(async () => await _service.CreateAsync(newAccommodation));
    }
}
