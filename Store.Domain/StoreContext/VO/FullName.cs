using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.VO
{
    public class FullName : Notifiable
    {
        public FullName(string text)
        {
            Text = text;

            AddNotifications(new ValidationContract()
                .Requires()
                .Matchs(Text, "^[\\p{L} .'-]+$", "UserName", "Invalid UserName. Must have at least 3 and at most 20 characters")
            );
        }

        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
