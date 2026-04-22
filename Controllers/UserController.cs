using Microsoft.AspNetCore.Mvc;
using User_Management_API.Data;
using User_Management_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using User_Management_API.Repositories;
using User_Management_API.Services;
using System.Threading.Tasks;
using User_Management_API.DTOs;

namespace User_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);
            
            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { token });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsers(RegisterDto registerDto)
        {
            var user= await _userService.RegisterAsync(registerDto);
            if (user == null) return NotFound(registerDto);
            return CreatedAtAction(nameof(GetUser),new {id=user.Id },user);
        }

    }
}
