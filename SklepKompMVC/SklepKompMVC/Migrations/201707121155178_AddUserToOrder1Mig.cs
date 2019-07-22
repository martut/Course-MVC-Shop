namespace SklepKompMVC.Migrations.MigrationsA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToOrder1Mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserDataId", "dbo.UserDatas");
            DropIndex("dbo.Orders", new[] { "UserDataId" });
            AlterColumn("dbo.Orders", "UserDataId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "UserDataId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "UserDataId");
            AddForeignKey("dbo.Orders", "UserDataId", "dbo.UserDatas", "UserDataId");
        }
    }
}
