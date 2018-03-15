using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Context.Entities;
using Store.Domain.StoreContext.Repositories;
using Store.Infra.StoreContext.DataContext;

namespace Store.Infra.StoreContext.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDataContext _context;

        public UserRepository(StoreDataContext context)
        {
            _context = context;
        }

        public bool EmailExists(string email) => _context.Users.Any(x => x.Email.ToString() == email);

        public bool UserNameExists(string userName) => _context.Users.Any(x => x.UserName.ToString() == userName);

        public async Task<IEnumerable<User>> Get() => await _context.Users.ToListAsync();

        public async Task Save(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
