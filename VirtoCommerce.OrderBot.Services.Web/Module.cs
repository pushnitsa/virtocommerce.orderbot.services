using Microsoft.Practices.Unity;
using System;
using VirtoCommerce.CustomerModule.Data.Model;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.CustomerModule.Data.Services;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.OrderBot.Services.Core.Models;
using VirtoCommerce.OrderBot.Services.Data.Models;
using VirtoCommerce.OrderBot.Services.Data.Repositories;
using VirtoCommerce.OrderBot.Services.Data.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace VirtoCommerce.OrderBot.Services.Web
{
    public class Module : ModuleBase
    {
        private readonly string _connectionString = ConfigurationHelper.GetConnectionStringValue("VirtoCommerce.OrderBot.Services") ?? ConfigurationHelper.GetConnectionStringValue("VirtoCommerce");
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public override void SetupDatabase()
        {
            base.SetupDatabase();

            using (var db = new BotContactRepository(_connectionString, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<BotContactRepository, Data.Migrations.Configuration>();
                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            BotContactRepository BotContactRepository() => new BotContactRepository(_connectionString, _container.Resolve<AuditableInterceptor>(), new EntityPrimaryKeyGeneratorInterceptor());

            _container.RegisterInstance<Func<ICustomerRepository>>(BotContactRepository);
            _container.RegisterInstance<Func<IMemberRepository>>(BotContactRepository);

            _container.RegisterType<CommerceMembersServiceImpl, BotContactMembersService>();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

            AbstractTypeFactory<Member>.OverrideType<Contact, BotContact>().MapToType<BotContactEntity>();
            AbstractTypeFactory<MemberDataEntity>.OverrideType<ContactDataEntity, BotContactEntity>();
            AbstractTypeFactory<MembersSearchCriteria>.OverrideType<MembersSearchCriteria, BotContactSearchCriteria>();
        }
    }
}
