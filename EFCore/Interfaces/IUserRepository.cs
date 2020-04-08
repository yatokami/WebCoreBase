using EFCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetListAsync();

        Task<User> GetInfoAsync(int id);
        void Save(User user);
        void Delete(User user);
        Task<bool> SaveChangesAsync();
    }
}