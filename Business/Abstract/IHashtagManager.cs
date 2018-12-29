using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHashtagManager
    {
      
        Hashtag GetHashTagByName(string hashtag);
        Hashtag CreateHashtag(string hashtag);
    }
}
