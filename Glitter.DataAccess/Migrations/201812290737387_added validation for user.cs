namespace Glitter.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvalidationforuser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Users", "ContactNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Country", c => c.String(nullable: false));
            CreateIndex("dbo.Users", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            AlterColumn("dbo.Users", "Country", c => c.String());
            AlterColumn("dbo.Users", "ContactNumber", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
        }
    }
}
