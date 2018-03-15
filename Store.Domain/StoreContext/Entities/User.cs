using Store.Domain.StoreContext.VO;
using Store.Shared.Entities;
using System;
using FluentValidator;

namespace Store.Domain.Context.Entities
{
    public class User : Entity
    {
        public FullName FullName { get; private set; }
        public UserName UserName { get; private set; }
        public Password Password { get; private set; }
        public Email Email { get; private set; }
        public DateTime CreationDate { get; private set; }

        public User(FullName fullName, UserName userName, Password password, Email email)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Email = email;
            CreationDate = DateTime.Now;
        }
    }
}
