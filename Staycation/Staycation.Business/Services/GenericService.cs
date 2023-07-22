using Microsoft.EntityFrameworkCore;
using Staycation.Business.Interfaces;
using Staycation.Data;
using Staycation.Data.Entities;

namespace Staycation.Business.Services;

public class GenericService<TEntity> : IService
    where TEntity : BaseEntity
{
    protected readonly StaycationContext _context;

    public GenericService(StaycationContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(int id)
    {
        await _context.Set<TEntity>().Where(x => x.Id == id).ExecuteDeleteAsync();
    }
}
