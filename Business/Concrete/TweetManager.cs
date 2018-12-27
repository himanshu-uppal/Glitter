using Business.Abstract;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TweetManager:ITweetManager
    {
        private readonly IGlitterService _glitterService;
        public TweetManager(IGlitterService glitterService)
        {
            _glitterService = glitterService;

        }
        public IQueryable<Tweet> GetTweets()
        {
            return _glitterService.GetAllTweets();
        }
    }
}
