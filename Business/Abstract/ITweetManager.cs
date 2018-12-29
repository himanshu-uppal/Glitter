using Glitter.DataAccess;
using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITweetManager
    {
        

        PaginatedList<Tweet> GetTweets();
        IEnumerable<Tweet> GetUserDashboardTweets(Guid userKey);
        Tweet GetTweet(Guid key);
        Tweet CreateTweet(Tweet tweet);
        Tweet UpdateTweet(Tweet oldTweet, string newTweetMessage);
        bool DeleteTweet(Tweet tweet);
    }
}
