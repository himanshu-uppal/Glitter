﻿using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Services
{
    public interface IGlitterService
    {
        PaginatedList<Tweet> GetTweets(int pageIndex, int pageSize);
        IEnumerable<Tweet> GetAllTweets();

        IEnumerable<User> GetUserFollowers(Guid userKey);
        IEnumerable<User> GetUserFollowees(Guid userKey);
        bool AddFollowee(Guid followerKey, Guid followeeKey);
        bool RemoveFollowee(Guid followerKey, Guid followeeKey);

        Tweet GetTweet(Guid key);
        Tweet CreateTweet(Tweet tweet,IEnumerable<Hashtag> hashtags);

        Hashtag GetHashtagByName(string hashtagName);
        Hashtag CreateHashtag(string hashtagName);


    }
}
