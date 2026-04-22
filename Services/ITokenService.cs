using User_Management_API.Models;

namespace User_Management_API.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
