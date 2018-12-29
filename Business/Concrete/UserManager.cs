using Business.Abstract;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Services;
using Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager:IUserManager
    {
        private readonly IMembershipService _membershipService;

        public UserManager(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }
        public bool ValidateUser(string email, string password)
        {
            return _membershipService.ValidateUser(email, password);
        }

        public OperationResult<User> CreateUser(User user, string password)
        {
            return _membershipService.CreateUser( user,  password);
        }

        public User GetSingleUser(Guid Key)
        {
            return _membershipService.GetSingleUser(Key);
        }

        public User UpdateUser(User user, string username, string email)
        {
            return _membershipService.UpdateUser(user,username,email);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return _membershipService.ChangePassword(username,oldPassword,newPassword);
        }


        public IEnumerable<User> GetUsers()
        {
            return _membershipService.GetUsers();
        }
        public User GetUser(Guid key)
        {
            return _membershipService.GetUser(key);
        }
        public User GetUser(string name)
        {
            return _membershipService.GetUser(name);

        }
        public User GetUserByEmail(string email)
        {
            return _membershipService.GetUserByEmail(email);
        }
    }
}
