using Glitter.DataAccess.Abstract;
using Glitter.DataAccess.Entities;
using Glitter.DataAccess.Extensions;
using Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glitter.DataAccess.Services
{
    public class MembershipService:IMembershipService
    {
        // variable to hold all users fetched as Entity Repository
        private readonly IEntityRepository<User> _userRepository;

       
        //variable to refer to crypto service
        private readonly ICryptoService _cryptoService;

        public MembershipService(IEntityRepository<User> userRepository,         
            ICryptoService cryptoService)
        {
            this._userRepository = userRepository;
            
            this._cryptoService = cryptoService;

        }

        /// <summary>
        /// this function checks whether the user is a valid user or not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>returns valid user context with principal and user details</returns>
        public bool ValidateUser(string email, string password)
        {


            //getting the user using the email given
            var user = _userRepository.GetUserByEmail(email); //implement extension method

            //if user is null
            if (user == null)
            {
                //returns empty user context
                //return userContext;
                return false;
            }

            //validating password and if valid then
            if (isPasswordValid(user, password))
            {

                return true;

            
            }

            //return userContext;
            return false;
        }

      
        /// <summary>
        /// main create user which is called by every other create user method
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>        
        /// <returns>return object of Operation Result containing true/false and the user created</returns>
        public OperationResult<User> CreateUser(User user, string password)
        {
            //getting all users having the same username
            var existingUser = _userRepository.GetAll().Any(x => x.Email == user.Email);

            //if username alraedy exists in the database
            if (existingUser)
            {
                return new OperationResult<User>(false);
            }

            //creating salt for generating the password
            var passwordSalt = _cryptoService.GenerateSalt();

            //creating user object using User model
            var newUser = new User()
            {
                Key = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Salt = passwordSalt,
                Email = user.Email,
                HashedPassword = _cryptoService.EncryptPassword(password, passwordSalt),
                ProfileImageData = user.ProfileImageData,
                ProfileImageMimeType = user.ProfileImageMimeType,
                ContactNumber = user.ContactNumber,
                Country = user.Country,
                CreatedOn = DateTime.Now

            };

            //adding newly created user to repository
            _userRepository.Add(newUser);

            //saving the user repository
            _userRepository.Save();

         

            //setting true to result and created user to Entity
            return new OperationResult<User>(true)
            {
                Entity = newUser
            };
        }


       


        public User UpdateUser(User user, string username, string email)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

      

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
        public User GetUser(Guid key)
        {
            var user = _userRepository.GetSingle(key);

            return user;
        }

        /// <summary>
        /// to get the user using user key
        /// </summary>
        /// <param name="Key"></param>
        /// <returns>user model object </returns>
        public User GetSingleUser(Guid Key)
        {
            var user = _userRepository.GetSingle(Key);

            return user;
        }
        public User GetUser(string name)
        {
            throw new NotImplementedException();
        }

        // Private helpers



        /// <summary>
        /// to validate the password
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>true if password is valid , else false</returns>
        private bool isPasswordValid(User user, string password)
        {
            //encrypting password using salt of the user
            var userEnteredPasswordHash = _cryptoService.EncryptPassword(password, user.Salt);

            //comparing hash created with given password and hash stored in user database
            return string.Equals(userEnteredPasswordHash, user.HashedPassword);
        }

     
       


        /// <summary>
        /// validating the user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>true if user is valid, else false</returns>
        private bool isUserValid(User user, string password)
        {
            //calling isPasswordValid method
            if (isPasswordValid(user, password))
            {
                return true;
            }
            return false;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }


    }
}
