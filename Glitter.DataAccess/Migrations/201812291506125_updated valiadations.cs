namespace Glitter.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedvaliadations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tweets", "Message", c => c.String(nullable: false, maxLength: 240));
            AlterColumn("dbo.Hashtags", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hashtags", "Name", c => c.String());
            AlterColumn("dbo.Tweets", "Message", c => c.String());
        }
    }
}
