namespace SklepKompMVC.Migrations.MigrationsA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToOrderMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserDataId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserDataId");
            AddForeignKey("dbo.Orders", "UserDataId", "dbo.UserDatas", "UserDataId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserDataId", "dbo.UserDatas");
            DropIndex("dbo.Orders", new[] { "UserDataId" });
            DropColumn("dbo.Orders", "UserDataId");
        }
    }
}
