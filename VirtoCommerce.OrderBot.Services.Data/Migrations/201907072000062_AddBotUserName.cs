namespace VirtoCommerce.OrderBot.Services.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBotUserName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BotContact",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BotUserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Id)
                .Index(t => t.Id);

            Sql("INSERT INTO dbo.BotContact (Id) SELECT Id FROM dbo.Contact");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BotContact", "Id", "dbo.Contact");
            DropIndex("dbo.BotContact", new[] { "Id" });
            DropTable("dbo.BotContact");
        }
    }
}
