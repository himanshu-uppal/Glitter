using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Extensions
{
    public static class UserRepositoryExtensions
    {
        public static User GetUserByEmail(
        this IEntityRepository<User> userRepository, string email)
        {
            return userRepository.GetAll().FirstOrDefault(u => u.Email == email);
        }

        public static IEnumerable<User> SearchPeople(this IEntityRepository<User> userRepository, string text)
        {
            return userRepository.GetAll().Where(u => u.FirstName.Contains(text) ||  u.LastName.Contains(text) || u.Email.Contains(text));
        }
    }
}
