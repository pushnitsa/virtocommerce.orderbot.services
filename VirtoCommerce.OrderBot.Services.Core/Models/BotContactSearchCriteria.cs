using VirtoCommerce.Domain.Customer.Model;

namespace VirtoCommerce.OrderBot.Services.Core.Models
{
    public class BotContactSearchCriteria : MembersSearchCriteria
    {
        public string BotUserName { get; set; }
    }
}
