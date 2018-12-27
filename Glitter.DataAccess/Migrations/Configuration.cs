namespace Glitter.DataAccess.Migrations
{
    using Glitter.DataAccess.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Glitter.DataAccess.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Glitter.DataAccess.Concrete.EFDbContext context)
        {
            //User user1 = new User { Key = Guid.NewGuid(), FirstName = "user1", CreatedOn = DateTime.Now };
            //User user2 = new User { Key = Guid.NewGuid(), FirstName = "user2" , CreatedOn = DateTime.Now };
            //User user3 = new User { Key = Guid.NewGuid(), FirstName = "user3", CreatedOn = DateTime.Now };
            //User user4 = new User { Key = Guid.NewGuid(), FirstName = "user4", CreatedOn = DateTime.Now };

            //context.Users.AddOrUpdate(user1, user2, user3, user4);

            //Tweet tweet1 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 1", User = user1, CreatedOn = DateTime.Now };
            //Tweet tweet2 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 2", User = user2 , CreatedOn = DateTime.Now };
            //Tweet tweet3 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 3", User = user3,CreatedOn = DateTime.Now };
            //Tweet tweet4 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 4", User = user4 , CreatedOn = DateTime.Now };
            //Tweet tweet5 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 5", User = user1, CreatedOn = DateTime.Now };
            //Tweet tweet6 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 6", User = user2 , CreatedOn = DateTime.Now };

            //context.Tweets.AddOrUpdate(tweet1, tweet2, tweet3, tweet4, tweet5, tweet6);

            //UserFollower userFollower1 = new UserFollower { Key = Guid.NewGuid(), Follower = user1, Followee = user2 };
            //UserFollower userFollower2 = new UserFollower { Key = Guid.NewGuid(), Follower = user1, Followee = user3 };
            //UserFollower userFollower3 = new UserFollower { Key = Guid.NewGuid(), Follower = user1, Followee = user4 };
            //UserFollower userFollower4 = new UserFollower { Key = Guid.NewGuid(), Follower = user2, Followee = user1 };

            //context.UserFollowers.AddOrUpdate(userFollower1, userFollower2, userFollower3, userFollower4);






        }
    }
}
