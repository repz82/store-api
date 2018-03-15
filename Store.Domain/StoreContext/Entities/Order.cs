using Store.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Store.Domain.Context.Entities
{
    public class Order : Entity
    {
        public string Number { get; private set; }
        public User User { get; private set; }
        public DateTime CreationDate { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }

        public Order(User user)
        {
            Number = $"{DateTime.Now.ToString("yyyyMMdd")}{(Guid.NewGuid().ToString().Replace("-","").Substring(0,8))}";
            User = user;
            CreationDate = DateTime.Now;
            Items = new List<OrderItem>();
        }
    }
}
