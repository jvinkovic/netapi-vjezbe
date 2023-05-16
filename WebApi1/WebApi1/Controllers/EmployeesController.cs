using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    [HttpGet]
    public List<int> GetAll()
    {
        return new List<int> { 4, 5, 6, 22 };
    }
}
