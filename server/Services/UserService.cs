using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using server.Helpers;
using server.Models.User;
using server.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace server.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(long id);
        Task<User> Create(User user, string Password);
        void Update(User user, string password = null);
        Task DeleteAsync(int id);
    }
    public class UserService : IUserService
    {
        private readonly ModelContext _context;
        private readonly AppSettings _appSettings;
        private readonly UserRepository _userRepository;
        public UserService(ModelContext context,UserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public User Authenticate(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(user => user.Username == username);
            if (user == null) return null;

            if (!VerifyPasswordHash(password, user.Password)){
                return null;
            }
            string token = BuildToken(user.Email, user.UserId, user.Role);
            user.Token = token;
            // remove password before returning
            user.Password = null;
            return user;
        }
        private string BuildToken(string Email, long Id, string Role)
        {
            // authentication successful so generate jwt token
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret));
            var token = new JwtTokenBuilder()
                .AddSecurityKey(securityKey)
                .AddExpiry(30)
                .AddClaim("Id", Id.ToString())
                .AddRole(Role)
                .AddClaim("Email", Email)
                .Build();
            return token;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.ListAsync(x=>1==1);
        }
        private static string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        private static bool VerifyPasswordHash(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
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
            User.DateModified = DateTime.Now;
            User.Role = Role.User;
            User.Token = null;
            await _userRepository.AddAsync(User);
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
                user.DateModified = DateTime.Now;
            _context.Users.Update(user);
            _context.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user != null)
            {
                _userRepository.Remove(user);
            }
            else
            {
                throw new AppException("No User Found");
            }
        }

        public async Task<User> GetById(long id)
        {
            var user = await _userRepository.FindByIdAsync(id);
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
