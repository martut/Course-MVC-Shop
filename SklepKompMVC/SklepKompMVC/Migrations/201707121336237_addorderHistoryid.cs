namespace SklepKompMVC.Migrations.MigrationsA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorderHistoryid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderHistoryId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderHistoryId");
        }
    }
}
