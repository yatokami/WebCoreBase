using EFCore.Interfaces;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebContext _webContext;

        public UserRepository(WebContext webContext)
        {
            _webContext = webContext;
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            return await _webContext.User.ToListAsync();
        }

        public async Task<User> GetInfoAsync(int id)
        {
            return await _webContext.User.SingleAsync(u => u.Id == id);
        }

        public void Save(User user)
        {
            _webContext.User.Add(user);
        }

        public void Delete(User user)
        {
            _webContext.User.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _webContext.SaveChangesAsync() > 0;
        }
    }
}
