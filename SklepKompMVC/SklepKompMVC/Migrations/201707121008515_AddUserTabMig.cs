namespace SklepKompMVC.Migrations.MigrationsA
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserTabMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDatas",
                c => new
                    {
                        UserDataId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        AddresCode = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserDataId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDatas");
        }
    }
}
