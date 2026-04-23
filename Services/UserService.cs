using User_Management_API.DTOs;
using User_Management_API.Models;
using User_Management_API.Repositories;

namespace User_Management_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users= await _repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
        public async Task<UserDto?> RegisterAsync(RegisterDto registerdto)
        {
            var user = new User
            {
                Name = registerdto.Name,
                Email = registerdto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerdto.Password),
                Phone=registerdto.Phone
            };
            await _repository.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<string?> LoginAsync(LoginDto loginDto)
        {
            var user = await _repository.GetByEmailAsync(loginDto.Email);
            
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                return null;
            
                
            return _tokenService.GenerateToken(user);
        }
    }
}
