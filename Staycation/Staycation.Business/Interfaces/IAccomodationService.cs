using Staycation.Business.DTO;

namespace Staycation.Business.Interfaces;

public interface IAccomodationService
{
    IEnumerable<AccommodationDTO> GetAll();
}
