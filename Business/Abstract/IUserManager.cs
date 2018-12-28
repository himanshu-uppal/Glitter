using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Classes;
using Glitter.DataAccess.Entities;

namespace Business.Abstract
{
    public interface IUserManager
    {

        bool ValidateUser(string username, string password);

        OperationResult<User> CreateUser(string username, string email, string password);

        User GetSingleUser(Guid Key);

        User UpdateUser(User user, string username, string email);

        bool ChangePassword(string username, string oldPassword, string newPassword);


        IEnumerable<User> GetUsers();
        User GetUser(Guid key);
        User GetUser(string name);
        User GetUserByEmail(string email);

    }
}
