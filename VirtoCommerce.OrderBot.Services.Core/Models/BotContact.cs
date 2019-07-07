using VirtoCommerce.Domain.Customer.Model;

namespace VirtoCommerce.OrderBot.Services.Core.Models
{
    public class BotContact : Contact
    {
        public BotContact()
        {
            MemberType = typeof(Contact).Name;
        }

        public string BotUserName { get; set; }
    }
}
