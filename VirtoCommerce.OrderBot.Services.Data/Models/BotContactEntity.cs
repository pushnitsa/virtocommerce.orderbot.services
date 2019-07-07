using System.ComponentModel.DataAnnotations;
using VirtoCommerce.CustomerModule.Data.Model;

namespace VirtoCommerce.OrderBot.Services.Data.Models
{
    public class BotContactEntity : ContactDataEntity
    {
        [StringLength(128)]
        public string BotUserName { get; set; }

        //public override Member ToModel(Member member)
        //{
        //    var result = base.ToModel(member);

        //    var botContact = (BotContact) result;
        //    botContact.BotUserName = BotUserName;

        //    return result;

        //}

        //public override MemberDataEntity FromModel(Member member, PrimaryKeyResolvingMap pkMap)
        //{
        //    base.FromModel(member, pkMap);

        //    var botContact = (BotContact) member;
        //    BotUserName = botContact.BotUserName;

        //    return this;
        //}

        public override void Patch(MemberDataEntity target)
        {
            base.Patch(target);

            var botContactEntity = (BotContactEntity)target;
            botContactEntity.BotUserName = BotUserName;
        }
    }
}
