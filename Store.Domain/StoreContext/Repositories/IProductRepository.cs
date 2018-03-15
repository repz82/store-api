using Store.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.StoreContext.Repositories
{
    public interface IProductRepository
    {
        Task Save(Product product);
        Task<IEnumerable<Product>> Get();
    }
}