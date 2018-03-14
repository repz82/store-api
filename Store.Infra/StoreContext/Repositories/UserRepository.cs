using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<User> Get() => _context.Users;

        public void Save(User user) => _context.Users.Add(user);

        public bool UserNameExists(string userName) => _context.Users.Any(x => x.UserName.ToString() == userName);
    }
}
