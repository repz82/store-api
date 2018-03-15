using Store.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.StoreContext.Repositories
{
    public interface IUserRepository
    {
        bool UserNameExists(string userName);
        bool EmailExists(string email);
        Task Save(User user);
        Task<IEnumerable<User>> Get();
    }
}
