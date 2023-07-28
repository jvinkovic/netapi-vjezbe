using Microsoft.IdentityModel.Tokens;
using Staycation.Business.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Staycation.Business.Services;

public class AuthService
{
    public string GenerateJSONWebToken(UserModel userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretGreatKey"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
            new Claim("StartDate", userInfo.StartDate.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(issuer: "notch.hr",
                                        claims: claims,
                                        expires: DateTime.Now.AddMinutes(120),
                                        signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public UserModel? AuthenticateUser(LoginModel login)
    {
        UserModel user = null;

        if (login.Username == "mbonn" && login.Pass == "1234")
        {
            user = new UserModel { Username = "mbonn", EmailAddress = "mike.bonn@notch.hr", StartDate = DateTime.UtcNow.AddMonths(27) };
        }
        return user;
    }
}
