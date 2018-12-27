using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;

namespace Glitter.DataAccess.Services
{
    public class GlitterService : IGlitterService
    {
        private readonly IEntityRepository<Tweet> _tweetRepository;
        public GlitterService(IEntityRepository<Tweet> tweetRepository)
        {
            _tweetRepository = tweetRepository;

        }
        public IQueryable<Tweet> GetAllTweets()
        {
            var tweets = _tweetRepository.GetAll();
            return tweets;
            
        }

        public PaginatedList<Tweet> GetTweets(int pageIndex, int pageSize)
        {
            var tweets = _tweetRepository.Paginate(pageIndex, pageSize, x => x.Key);
            return tweets;
        }
    }
}
