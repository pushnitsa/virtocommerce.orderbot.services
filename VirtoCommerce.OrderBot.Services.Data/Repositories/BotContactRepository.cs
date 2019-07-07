using System.Data.Entity;
using VirtoCommerce.CustomerModule.Data.Repositories;
using VirtoCommerce.OrderBot.Services.Data.Models;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace VirtoCommerce.OrderBot.Services.Data.Repositories
{
    public class BotContactRepository : CustomerRepositoryImpl
    {
        public BotContactRepository()
        {

        }

        public BotContactRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, interceptors)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BotContactEntity>().ToTable("BotContact").HasKey(x => x.Id).Property(x => x.Id);
            modelBuilder.Entity<BotContactEntity>().HasIndex(i => i.BotUserName).IsUnique(true);
        }

    }
}
