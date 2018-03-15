using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.VO
{
    public class UserName : Notifiable
    {
        public UserName(string text)
        {
            Text = text;

            AddNotifications(new ValidationContract()
                .Requires()
                .Matchs(Text, "^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", "UserName", "Invalid UserName. Must have at least 3 and at most 20 characters")
            );
        }

        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
