using FluentValidator;
using Store.Domain.Context.Entities;
using Store.Domain.StoreContext.Commands.Input;
using Store.Domain.StoreContext.Commands.Output;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.VO;
using Store.Shared.Commands;
using System.Threading.Tasks;

namespace Store.Domain.StoreContext.Handlers
{
    public class UserHandler : Notifiable,
        ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            if (_repository.UserNameExists(command.UserName))
                AddNotification("UserName", "UserName already exists");

            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "E-mail already exists");

            var fullName = new FullName(command.FullName);
            var userName = new UserName(command.UserName);
            var password = new Password(command.Password);
            var email = new Email(command.Email);
            var user = new User(fullName, userName, password, email);

            AddNotifications(fullName.Notifications);
            AddNotifications(userName.Notifications);
            AddNotifications(password.Notifications);
            AddNotifications(email.Notifications);

            if (Invalid)
                return new CommandResult(
                    false,
                    "Please, verify fields below",
                    Notifications);

            await _repository.Save(user);

            return new CommandResult(true, "Welcome to Store", new
            {
                user.Id,
                FullName = fullName.ToString(),
                UserName = userName.ToString(),
                Email = email.ToString()
            });
        }
    }
}
