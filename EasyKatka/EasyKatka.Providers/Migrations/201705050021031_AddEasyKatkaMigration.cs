namespace EasyKatka.Providers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEasyKatkaMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        TradingStart = c.DateTime(nullable: false),
                        ImagePath = c.String(),
                        StartPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lots");
        }
    }
}
