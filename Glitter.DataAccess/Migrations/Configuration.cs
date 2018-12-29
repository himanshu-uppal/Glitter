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
            //byte[] byteArray = new byte[10];
            //User user1 = new User
            //{
            //    Key = Guid.NewGuid(),
            //    FirstName = "userOne ",
            //    LastName = "userOne ",
            //    Email = "user1@gmail.com",
            //    ProfileImageData = byteArray,
            //    ProfileImageMimeType = "jpg",
            //    ContactNumber = "9999999999",
            //    Country = "IND",
            //    CreatedOn = DateTime.Now
            //};
            //User user2 = new User
            //{
            //    Key = Guid.NewGuid(),
            //    FirstName = "userTwo",
            //    LastName = "userTwo",
            //    Email = "user2@gmail.com",
            //    ProfileImageData = byteArray,
            //    ProfileImageMimeType = "jpg",
            //    ContactNumber = "9999999999",
            //    Country = "IND",
            //    CreatedOn = DateTime.Now
            //};
            //User user3 = new User
            //{
            //    Key = Guid.NewGuid(),
            //    FirstName = "userThree",
            //    LastName = "userThree",
            //    Email = "user3@gmail.com",
            //    ProfileImageData = byteArray,
            //    ProfileImageMimeType = "jpg",
            //    ContactNumber = "9999999999",
            //    Country = "IND",
            //    CreatedOn = DateTime.Now
            //};
            //User user4 = new User
            //{
            //    Key = Guid.NewGuid(),
            //    FirstName = "userFour",
            //    LastName = "userFour",
            //    Email = "user4@gmail.com",
            //    ProfileImageData = byteArray,
            //    ProfileImageMimeType = "jpg",
            //    ContactNumber = "9999999999",
            //    Country = "IND",
            //    CreatedOn = DateTime.Now
            //};

            //context.Users.AddOrUpdate(user1, user2, user3, user4);

            //Tweet tweet1 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 1", User = user1, CreatedOn = DateTime.Now };
            //Tweet tweet2 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 2", User = user2, CreatedOn = DateTime.Now };
            //Tweet tweet3 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 3", User = user3, CreatedOn = DateTime.Now };
            //Tweet tweet4 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 4", User = user4, CreatedOn = DateTime.Now };
            //Tweet tweet5 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 5", User = user1, CreatedOn = DateTime.Now };
            //Tweet tweet6 = new Tweet { Key = Guid.NewGuid(), Message = "Tweet 6", User = user2, CreatedOn = DateTime.Now };

            //context.Tweets.AddOrUpdate(tweet1, tweet2, tweet3, tweet4, tweet5, tweet6);

            //UserFollower userFollower1 = new UserFollower { Key = Guid.NewGuid(), Follower = user1, Followee = user2 };
            //UserFollower userFollower2 = new UserFollower { Key = Guid.NewGuid(), Follower = user1, Followee = user3 };
            //UserFollower userFollower3 = new UserFollower { Key = Guid.NewGuid(), Follower = user1, Followee = user4 };
            //UserFollower userFollower4 = new UserFollower { Key = Guid.NewGuid(), Follower = user2, Followee = user1 };

            //context.UserFollowers.AddOrUpdate(userFollower1, userFollower2, userFollower3, userFollower4);

            //Reaction reaction1 = new Reaction { Key = Guid.NewGuid(), Name = "Like" };
            //Reaction reaction2 = new Reaction { Key = Guid.NewGuid(), Name = "Dislike" };
            //Reaction reaction3 = new Reaction { Key = Guid.NewGuid(), Name = "Heart" };

            //context.Reactions.AddOrUpdate(reaction1, reaction2, reaction3);

            //TweetReaction tweetReaction1 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet1, Reaction = reaction1, User = user1 };
            //TweetReaction tweetReaction2 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet1, Reaction = reaction2, User = user2 };
            //TweetReaction tweetReaction3 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet1, Reaction = reaction3, User = user1 };
            //TweetReaction tweetReaction4 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet1, Reaction = reaction1, User = user3 };
            //TweetReaction tweetReaction5 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet2, Reaction = reaction1, User = user1 };
            //TweetReaction tweetReaction6 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet2, Reaction = reaction2, User = user3 };
            //TweetReaction tweetReaction7 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet3, Reaction = reaction1, User = user1 };
            //TweetReaction tweetReaction8 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet3, Reaction = reaction2, User = user4 };
            //TweetReaction tweetReaction9 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet3, Reaction = reaction3, User = user3 };
            //TweetReaction tweetReaction10 = new TweetReaction { Key = Guid.NewGuid(), Tweet = tweet4, Reaction = reaction1, User = user1 };

            //context.TweetReactions.AddOrUpdate(tweetReaction1, tweetReaction2, tweetReaction3, tweetReaction4, tweetReaction5, tweetReaction6,
            //    tweetReaction7, tweetReaction8, tweetReaction9, tweetReaction10);

            //Hashtag hashtag1 = new Hashtag { Key = Guid.NewGuid(), Name = "hashtag1" };
            //Hashtag hashtag2 = new Hashtag { Key = Guid.NewGuid(), Name = "hashtag2" };
            //Hashtag hashtag3 = new Hashtag { Key = Guid.NewGuid(), Name = "hashtag3" };
            //Hashtag hashtag4 = new Hashtag { Key = Guid.NewGuid(), Name = "hashtag4" };
            //Hashtag hashtag5 = new Hashtag { Key = Guid.NewGuid(), Name = "hashtag5" };

            //context.Hashtags.AddOrUpdate(hashtag1, hashtag2, hashtag3, hashtag4, hashtag5);

            //TweetHashtag tweetHashtag1 = new TweetHashtag { Key = Guid.NewGuid(), Tweet = tweet1, Hashtag = hashtag1 };
            //TweetHashtag tweetHashtag2 = new TweetHashtag { Key = Guid.NewGuid(), Tweet = tweet1, Hashtag = hashtag2 };
            //TweetHashtag tweetHashtag3 = new TweetHashtag { Key = Guid.NewGuid(), Tweet = tweet1, Hashtag = hashtag3 };
            //TweetHashtag tweetHashtag4 = new TweetHashtag { Key = Guid.NewGuid(), Tweet = tweet2, Hashtag = hashtag1 };
            //TweetHashtag tweetHashtag5 = new TweetHashtag { Key = Guid.NewGuid(), Tweet = tweet2, Hashtag = hashtag2 };
            //TweetHashtag tweetHashtag6 = new TweetHashtag { Key = Guid.NewGuid(), Tweet = tweet2, Hashtag = hashtag5 };

            //context.TweetHashtags.AddOrUpdate(tweetHashtag1, tweetHashtag2, tweetHashtag3, tweetHashtag4, tweetHashtag5);






        }
    }
}
