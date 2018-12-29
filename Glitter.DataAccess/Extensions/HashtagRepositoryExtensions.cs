using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Extensions
{
    public static class HashtagRepositoryExtensions
    {
        public static Hashtag GetHashtagByName(this IEntityRepository<Hashtag> hashtagRepository,string hashtag)
        {
            return hashtagRepository.GetAll().FirstOrDefault(h=>h.Name == hashtag);

        }
    }
}
