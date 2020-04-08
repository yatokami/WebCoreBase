using EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetListAsync();

        Task<User> GetInfoAsync(int id);

        Task<bool> SaveAsync(User user);
    }
}