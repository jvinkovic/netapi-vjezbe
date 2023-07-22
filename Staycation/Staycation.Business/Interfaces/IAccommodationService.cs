using Staycation.Business.DTO;

namespace Staycation.Business.Interfaces;

public interface IAccommodationService : IService
{
    Task<IEnumerable<AccommodationDTO>> GetAllAsync();

    Task<AccommodationDTO?> GetByIdAsync(int id);

    Task<AccommodationDTO?> CreateAsync(CreateEditAccommodationDTO model);

    Task<AccommodationDTO> UpdateAsync(int id, CreateEditAccommodationDTO model);
}
