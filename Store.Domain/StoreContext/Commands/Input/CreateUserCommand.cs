using FluentValidator;
using FluentValidator.Validation;
using Store.Domain.StoreContext.VO;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.Input
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .Matchs(UserName, "^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", "UserName", "Invalid UserName, must have at least 3 and at most 20 characters")
                .Matchs(FullName, "^[\\p{L} .'-]+$", "FullName", "Invalid FullName")
                .Matchs(Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{8,}", "Password", "Password must have at least 8 characters, one uppercase letter, one lowercase letter, one number and one special character")
                .IsEmail(Email, "Email", "Invalid e-mail")
            );
            return Valid;
        }
    }
}
