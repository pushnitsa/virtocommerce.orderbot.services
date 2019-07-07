using System;
using System.Linq.Expressions;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.CustomerModule.Data.Services;
using VirtoCommerce.Domain.Commerce.Services;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.OrderBot.Services.Core.Models;
using VirtoCommerce.OrderBot.Services.Data.Models;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;
using VirtoCommerce.Platform.Core.Events;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.OrderBot.Services.Data.Services
{
    public class BotContactMembersService : CommerceMembersServiceImpl
    {
        public BotContactMembersService(Func<ICustomerRepository> repositoryFactory, IDynamicPropertyService dynamicPropertyService, ICommerceService commerceService, ISecurityService securityService, IEventPublisher eventPublisher) 
            : base(repositoryFactory, dynamicPropertyService, commerceService, securityService, eventPublisher)
        {
        }

        protected override Expression<Func<MemberDataEntity, bool>> GetQueryPredicate(MembersSearchCriteria criteria)
        {
            var retVal = base.GetQueryPredicate(criteria);

            if (
                criteria is BotContactSearchCriteria botContactSearchCriteria &&
                !string.IsNullOrEmpty(botContactSearchCriteria.BotUserName)
                )
            {
                var predicate = PredicateBuilder.False<MemberDataEntity>();
                predicate = predicate.Or(c => c is BotContactEntity && (c as BotContactEntity).BotUserName == botContactSearchCriteria.BotUserName);

                retVal = LinqKit.Extensions.Expand(predicate);
            }

            return retVal;
        }
    }
}
