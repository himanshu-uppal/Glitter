namespace Glitter.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedallentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Message = c.String(),
                        Tweet_Key = c.Guid(),
                        User_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Tweets", t => t.Tweet_Key)
                .ForeignKey("dbo.Users", t => t.User_Key)
                .Index(t => t.Tweet_Key)
                .Index(t => t.User_Key);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Message = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdatedOn = c.DateTime(),
                        User_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Users", t => t.User_Key)
                .Index(t => t.User_Key);
            
            CreateTable(
                "dbo.TweetHashtags",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Hashtag_Key = c.Guid(),
                        Tweet_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Hashtags", t => t.Hashtag_Key)
                .ForeignKey("dbo.Tweets", t => t.Tweet_Key)
                .Index(t => t.Hashtag_Key)
                .Index(t => t.Tweet_Key);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.TweetImages",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        ImagePath = c.String(),
                        Tweet_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Tweets", t => t.Tweet_Key)
                .Index(t => t.Tweet_Key);
            
            CreateTable(
                "dbo.TweetReactions",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Reaction_Key = c.Guid(),
                        Tweet_Key = c.Guid(),
                        User_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Reactions", t => t.Reaction_Key)
                .ForeignKey("dbo.Tweets", t => t.Tweet_Key)
                .ForeignKey("dbo.Users", t => t.User_Key)
                .Index(t => t.Reaction_Key)
                .Index(t => t.Tweet_Key)
                .Index(t => t.User_Key);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        HashedPassword = c.String(),
                        Salt = c.String(),
                        ProfileImageData = c.Binary(),
                        ProfileImageMimeType = c.String(),
                        ContactNumber = c.String(),
                        Country = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        LastUpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.UserFollowers",
                c => new
                    {
                        Key = c.Guid(nullable: false),
                        Followee_Key = c.Guid(),
                        Follower_Key = c.Guid(),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Users", t => t.Followee_Key)
                .ForeignKey("dbo.Users", t => t.Follower_Key)
                .Index(t => t.Followee_Key)
                .Index(t => t.Follower_Key);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFollowers", "Follower_Key", "dbo.Users");
            DropForeignKey("dbo.UserFollowers", "Followee_Key", "dbo.Users");
            DropForeignKey("dbo.Tweets", "User_Key", "dbo.Users");
            DropForeignKey("dbo.TweetReactions", "User_Key", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Key", "dbo.Users");
            DropForeignKey("dbo.TweetReactions", "Tweet_Key", "dbo.Tweets");
            DropForeignKey("dbo.TweetReactions", "Reaction_Key", "dbo.Reactions");
            DropForeignKey("dbo.TweetImages", "Tweet_Key", "dbo.Tweets");
            DropForeignKey("dbo.TweetHashtags", "Tweet_Key", "dbo.Tweets");
            DropForeignKey("dbo.TweetHashtags", "Hashtag_Key", "dbo.Hashtags");
            DropForeignKey("dbo.Comments", "Tweet_Key", "dbo.Tweets");
            DropIndex("dbo.UserFollowers", new[] { "Follower_Key" });
            DropIndex("dbo.UserFollowers", new[] { "Followee_Key" });
            DropIndex("dbo.TweetReactions", new[] { "User_Key" });
            DropIndex("dbo.TweetReactions", new[] { "Tweet_Key" });
            DropIndex("dbo.TweetReactions", new[] { "Reaction_Key" });
            DropIndex("dbo.TweetImages", new[] { "Tweet_Key" });
            DropIndex("dbo.TweetHashtags", new[] { "Tweet_Key" });
            DropIndex("dbo.TweetHashtags", new[] { "Hashtag_Key" });
            DropIndex("dbo.Tweets", new[] { "User_Key" });
            DropIndex("dbo.Comments", new[] { "User_Key" });
            DropIndex("dbo.Comments", new[] { "Tweet_Key" });
            DropTable("dbo.UserFollowers");
            DropTable("dbo.Users");
            DropTable("dbo.Reactions");
            DropTable("dbo.TweetReactions");
            DropTable("dbo.TweetImages");
            DropTable("dbo.Hashtags");
            DropTable("dbo.TweetHashtags");
            DropTable("dbo.Tweets");
            DropTable("dbo.Comments");
        }
    }
}
