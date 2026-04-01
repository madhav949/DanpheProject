//using HospitalMangement.API.Data;
//using HospitalMangement.API.Models;
//using HospitalMangement.API.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//[Route("api/[controller]")]
//[ApiController]
//public class AuthController : ControllerBase
//{
//    private readonly HospitalDbContext _context;
//    private readonly IConfiguration _configuration;

//    public AuthController(HospitalDbContext context, IConfiguration configuration)
//    {
//        _context = context;
//        _configuration = configuration;
//    }

//    // REGISTER
//    [HttpPost("register")]
//    public async Task<IActionResult> Register(RegisterDto dto)
//    {
//        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
//            return BadRequest("User already exists");

//        var user = new User
//        {
//            FullName = dto.FullName,
//            Email = dto.Email,
//            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
//            Role = dto.Role
//        };

//        _context.Users.Add(user);
//        await _context.SaveChangesAsync();

//        return Ok("User registered successfully");
//    }

//    // LOGIN
//    [HttpPost("login")]
//    public async Task<IActionResult> Login(LoginDto dto)
//    {
//        var user = await _context.Users
//            .FirstOrDefaultAsync(u => u.Email == dto.Email);

//        if (user == null)
//            return Unauthorized("Invalid credentials");

//        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
//            return Unauthorized("Invalid credentials");

//        var token = GenerateJwtToken(user);

//        return Ok(new { Token = token });
//    }

//    private string GenerateJwtToken(User user)
//    {
//        var claims = new[]
//        {
//            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//            new Claim(ClaimTypes.Email, user.Email),
//            new Claim(ClaimTypes.Role, user.Role)
//        };

//        var key = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

//        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//        var token = new JwtSecurityToken(
//            issuer: _configuration["JwtSettings:Issuer"],
//            audience: _configuration["JwtSettings:Audience"],
//            claims: claims,
//            expires: DateTime.Now.AddMinutes(
//                Convert.ToDouble(_configuration["JwtSettings:DurationInMinutes"])),
//            signingCredentials: creds
//        );

//        return new JwtSecurityTokenHandler().WriteToken(token);
//    }
//}
