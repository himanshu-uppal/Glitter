using Business.Abstract;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HashtagManager:IHashtagManager
    {
        private readonly IGlitterService _glitterService;
        public HashtagManager(IGlitterService glitterService)
        {
            _glitterService = glitterService;

        }
        public Hashtag GetHashTagByName(string hashtag)
        {
            return _glitterService.GetHashtagByName(hashtag);

        }

        public Hashtag CreateHashtag(string hashtag)
        {
            return _glitterService.CreateHashtag(hashtag);
        }
    }
}
