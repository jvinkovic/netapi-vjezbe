using Microsoft.AspNetCore.Mvc;
using Staycation.Business.DTO;
using Staycation.Business.Interfaces;

namespace Staycation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccommodationController : ControllerBase
{
    private readonly IAccommodationService _service;

    public AccommodationController(IAccommodationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccommodationDTO>>> GetAll()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AccommodationDTO>> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<AccommodationDTO>> CreateAccomodation(CreateEditAccommodationDTO model)
    {
        return Ok(await _service.CreateAsync(model));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AccommodationDTO>> EditAccomodation(int id, CreateEditAccommodationDTO model)
    {
        return Ok(await _service.UpdateAsync(id, model));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAccomodation(int id)
    {
        await _service.DeleteAsync(id);

        return NoContent();
    }
}
