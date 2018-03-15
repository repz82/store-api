using Store.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.StoreContext.Repositories
{
    public interface IOrderRepository
    {
        Task Save(Order order);
        Task<IEnumerable<Order>> Get();
    }
}
