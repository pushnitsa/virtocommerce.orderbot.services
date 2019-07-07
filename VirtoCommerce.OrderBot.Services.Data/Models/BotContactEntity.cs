﻿using System.ComponentModel.DataAnnotations;
using VirtoCommerce.CustomerModule.Data.Model;

namespace VirtoCommerce.OrderBot.Services.Data.Models
{
    public class BotContactEntity : ContactDataEntity
    {
        [StringLength(128)]
        public string BotUserName { get; set; }

        public override void Patch(MemberDataEntity target)
        {
            base.Patch(target);

            var botContactEntity = (BotContactEntity)target;
            botContactEntity.BotUserName = BotUserName;
        }
    }
}
