using Microsoft.Practices.Unity;
using VirtoCommerce.OrderBot.Services.Data.Repositories;
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

            // This method is called for each installed module on the first stage of initialization.

            // Register implementations:
            // _container.RegisterType<IMyRepository>(new InjectionFactory(c => new MyRepository(_connectionString, new EntityPrimaryKeyGeneratorInterceptor()));
            // _container.RegisterType<IMyService, MyService>();

            // Try to avoid calling _container.Resolve<>();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

            // This method is called for each installed module on the second stage of initialization.

            // Override types using AbstractTypeFactory:
            // AbstractTypeFactory<BaseModel>.OverrideType<BaseModel, BaseModelEx>();
            // AbstractTypeFactory<BaseModelEntity>.OverrideType<BaseModelEntity, BaseModelExEntity>();

            // Resolve registered implementations:
            // var settingManager = _container.Resolve<ISettingsManager>();
            // var value = settingManager.GetValue("Pricing.ExportImport.Description", string.Empty);
        }
    }
}
