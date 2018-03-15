using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.VO
{
    public class Email : Notifiable
    {
        public Email(string text)
        {
            Text = text;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Text, "Email", "Invalid e-mail")
            );
        }

        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
