using System.IdentityModel.Tokens.Jwt;
using System.Net.Security;
using System.Security.Claims;
using System.Text;
using efcoreRestFull.Context;
using efcoreRestFull.DTOs;
using efcoreRestFull.Entities;
using efcoreRestFull.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Controllers;

[Route("auth")]
public class AuthController : ControllerBase
{
    private DataContext _context;
    private IConfiguration _config;
    private PasswordMigrationService _passwordMigrationService;

    public AuthController(IConfiguration config, DataContext context, PasswordMigrationService passwordMigrationService)
    {
        _config = config;
        _context = context;
        _passwordMigrationService = passwordMigrationService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLogin userLogin)
    {
        
        
        var user = Authenticate(userLogin);
        var profileResponse = _context.Customers.
            Where(c => c.Email == user.Email).
            Select(c => new userInfoDTO()
            {
                Id = c.Id,
                userName = c.Name,
                userEmail = c.Email,
                userSurname = c.Surname,
                userAddress = c.Address,
                basketId = _context.Baskets.FirstOrDefault(b=>b.CustomerId==c.Id).Id
            }); 
        if (user != null)
        { 
            var token = Generate(user);
            
            return Ok(new { token = token, profileResponse});
        }

        return NotFound();
    }

    private string? Generate(Customer customer)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("id", customer.Id.ToString()),
            new Claim("name", customer.Name),
            new Claim("email", customer.Email),
            new Claim("surname", customer.Surname),
            //new Claim(ClaimTypes.StreetAddress,customer.Password),
            new Claim("role", customer.CustomerRoles.FirstOrDefault()?.Role?.RoleName??"User"),
        };
      
        
        
        var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private Customer Authenticate(UserLogin userLogin)
    {
        var currentCustomer = _context.Customers
          .Include(c => c.CustomerRoles).ThenInclude(cr => cr.Role)
            .FirstOrDefault(o => o.Email.ToLower() == userLogin.Email.ToLower());

        
        

        if (currentCustomer != null)
        {
            var passwordMigrationService = new PasswordMigrationService(_context);


            bool isPasswordValid =
                passwordMigrationService.VerifyPassword(userLogin.Password, currentCustomer.Password);

            if (isPasswordValid)
            {
                return currentCustomer;
            }
        }

        return null;
    }
}