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
    }
}
