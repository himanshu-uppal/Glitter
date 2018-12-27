using Glitter.DataAccess.Entities;
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

    
    }
}
