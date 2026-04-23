using System.Collections.Generic;
using System.Threading.Tasks;
using User_Management_API.Models;

namespace User_Management_API.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
