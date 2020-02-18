using server.Helpers;
using server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        Task<User> GetById(long id);
        Task<User> Create(User user, string Password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private readonly UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;
        }
        public User Authenticate(string username, string password)
        {

            var user = _context.Users.SingleOrDefault(user => user.Username == username && user.Password == password);
            if (user == null) return null;

            if (!VerifyPasswordHash(password, user.Password)){
                return null;
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
        private static string CreatePasswordHash(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(password);
            var hashed = sha1.ComputeHash(data);
            string hashedPassword = hashed.ToString();
            return hashedPassword;
        }
        private static bool VerifyPasswordHash(string password, string storedHash)
        {
            string hashedPassword = CreatePasswordHash(password);
            if (hashedPassword == storedHash) return true;
            return false;
        }

        public async Task<User> Create(User User, string Password)
        {
            if (string.IsNullOrWhiteSpace(Password))
                throw new AppException("Password is required");
            // throw error if the new username is already taken
            if (_context.Users.Any(x => x.Username == User.Username))
                throw new AppException("Username \"" + User.Username + "\" is already taken");

            string passwordHash = CreatePasswordHash(Password);
            User.Password = passwordHash;
            User.DateCreated = DateTime.Now;
            User.DateMofied = DateTime.Now;
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public void Update(User userParams, string Password = null)
        {
            var user = _context.Users.Find(userParams.UserId);
            bool isChanged = false;
            if (user == null) throw new AppException("User not found");

            //update username if it has changed
            if(!string.IsNullOrWhiteSpace(userParams.Username) && userParams.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_context.Users.Any(x => x.Username == userParams.Username))
                    throw new AppException("Username " + userParams.Username + " is already taken");
                user.Username = userParams.Username;
                isChanged = true;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParams.Firstname))
                user.Firstname = userParams.Firstname; isChanged = true;


            if (!string.IsNullOrWhiteSpace(userParams.Lastname))
                user.Lastname = userParams.Lastname; isChanged = true;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(Password))
            {
                string hashedPassword = CreatePasswordHash(Password);

                user.Password = hashedPassword; isChanged = true;
            }
            if (isChanged)
                user.DateMofied = DateTime.Now;
            _context.Users.Update(user);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new AppException("No User Found");
            }
        }

        public async Task<User> GetById(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new AppException("No User Found");
            }
        }
    }
}
