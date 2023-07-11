using Microsoft.AspNetCore.Mvc;
using Staycation.Business.Interfaces;

namespace Staycation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccommodationController : ControllerBase
{
    private readonly IAccomodationService _service;

    public AccommodationController(IAccomodationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = _service.GetAll();

        return Ok(result);
    }
}
