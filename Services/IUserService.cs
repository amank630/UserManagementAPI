using User_Management_API.DTOs;

namespace User_Management_API.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto?> RegisterAsync(RegisterDto registerdto);
        Task<string?> LoginAsync(LoginDto loginDto);
    }
}
