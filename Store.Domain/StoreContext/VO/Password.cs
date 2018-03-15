using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.VO
{
    public class Password : Notifiable
    {
        public Password(string text)
        {
            Text = text;

            AddNotifications(new ValidationContract()
                .Requires()
                .Matchs(Text, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{8,}", "Email", "O E-mail é inválido")
            );
        }

        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
