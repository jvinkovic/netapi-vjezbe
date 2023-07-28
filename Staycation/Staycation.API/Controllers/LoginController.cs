using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Staycation.Business.Models;
using Staycation.Business.Services;
using System.Net;

namespace Staycation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LoginController : ControllerBase
{
    private AuthService _authService;

    public LoginController(AuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] LoginModel login)
    {
        IActionResult response = Unauthorized();
        var user = _authService.AuthenticateUser(login);

        if (user != null)
        {
            var tokenString = _authService.GenerateJSONWebToken(user);
            response = Ok(new { token = tokenString });
        }

        return response;
    }

    [HttpGet("/api/me/started")]
    public IActionResult HasStarted()
    {
        var currentUser = HttpContext.User;
        int spendingTimeWithCompany = 0;

        if (currentUser.HasClaim(c => c.Type == "StartDate"))
        {
            DateTime date = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "StartDate").Value);
            spendingTimeWithCompany = DateTime.Today.Year - date.Year;
        }

        if (spendingTimeWithCompany > 0)
        {
            return Ok("Employee");
        }
        else
        {
            return StatusCode((int)HttpStatusCode.Forbidden, "Not started");
        }
    }
}
