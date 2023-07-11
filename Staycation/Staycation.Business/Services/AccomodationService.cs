using Staycation.Business.DTO;
using Staycation.Business.Interfaces;
using Staycation.Data;

namespace Staycation.Business.Services;

public class AccomodationService : IAccomodationService
{
    public IEnumerable<AccommodationDTO> GetAll()
    {
        var list = TestData.Accommodations.Select(x => new AccommodationDTO
        {
            Id = x.Id,
            Categorisation = x.Categorisation,
            Description = x.Description,
            FreeCancellation = x.FreeCancellation,
            ImageUrl = x.ImageUrl,
            LocationId = x.LocationId,
            PersonCount = x.PersonCount,
            Price = x.Price,
            Subtitle = x.Subtitle,
            Title = x.Title,
            Type = x.Type
        });

        return list;
    }
}
