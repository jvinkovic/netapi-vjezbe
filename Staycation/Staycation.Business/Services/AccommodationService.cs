using Microsoft.EntityFrameworkCore;
using Staycation.Business.DTO;
using Staycation.Business.Interfaces;
using Staycation.Data;
using Staycation.Data.Entities;

namespace Staycation.Business.Services;

public class AccommodationService : GenericService<Accommodation>, IAccommodationService
{
    public AccommodationService(StaycationContext context) : base(context)
    { }

    public async Task<IEnumerable<AccommodationDTO>> GetAllAsync()
    {
        var list = await _context.Accommodations.Select(x => new AccommodationDTO
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
        }).ToListAsync();

        return list;
    }

    public async Task<AccommodationDTO?> GetByIdAsync(int id)
    {
        var entity = await _context.Accommodations.AsNoTracking().Include(x => x.Location).SingleOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            return null;
        }

        return new AccommodationDTO
        {
            Id = entity.Id,
            Categorisation = entity.Categorisation,
            Description = entity.Description,
            FreeCancellation = entity.FreeCancellation,
            ImageUrl = entity.ImageUrl,
            LocationId = entity.LocationId,
            PersonCount = entity.PersonCount,
            Price = entity.Price,
            Subtitle = entity.Subtitle,
            Title = entity.Title,
            Type = entity.Type,
            Location = new LocationDTO()
            {
                Id = entity.Location.Id,
                ImageUrl = entity.Location.ImageUrl,
                Name = entity.Location.Name,
                PostalCode = entity.Location.PostalCode
            }
        };
    }

    public async Task<AccommodationDTO?> CreateAsync(CreateEditAccommodationDTO model)
    {
        var entity = new Accommodation
        {
            Categorisation = model.Categorisation,
            Description = model.Description,
            FreeCancellation = model.FreeCancellation,
            ImageUrl = model.ImageUrl,
            LocationId = model.LocationId,
            PersonCount = model.PersonCount,
            Price = model.Price,
            Subtitle = model.Subtitle,
            Title = model.Title,
            Type = model.Type
        };

        await _context.Accommodations.AddAsync(entity);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(entity.Id);
    }

    public async Task<AccommodationDTO?> UpdateAsync(int id, CreateEditAccommodationDTO model)
    {
        var entity = await _context.Accommodations.SingleOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            return null;
        }

        entity.Categorisation = model.Categorisation;
        entity.Description = model.Description;
        entity.FreeCancellation = model.FreeCancellation;
        entity.ImageUrl = model.ImageUrl;
        entity.LocationId = model.LocationId;
        entity.PersonCount = model.PersonCount;
        entity.Price = model.Price;
        entity.Subtitle = model.Subtitle;
        entity.Title = model.Title;
        entity.Type = model.Type;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(entity.Id);
    }
}
