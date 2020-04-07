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
    }
}
