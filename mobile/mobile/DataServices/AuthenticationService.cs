using mobile.DataServices.Interface;
using mobile.Helpers;
using mobile.Models;
using mobile.Models.Enums;
using mobile.Plugins.Interface;
using mobile.Services;
using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile.DataServices
{
    public class AuthenticationService : ApiService ,IAuthenticationService
    {
        private ISecureStorage _storage;
        public AuthenticationService(IStorage storage)
        {
            _storage = storage.SecureStorage;
        }
        public bool IsLoggedIn()
        {
            var token = _storage.GetValue(StorageKeys.ACCESS_TOKEN.Value);
            return token != null;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var token = await Login(username, password);
            if (token != null)
            {
                _storage.SetValue(StorageKeys.ACCESS_TOKEN.Value, token);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> RegisterAsync(string firstname, string lastname, string email, string username, string password)
        {
            return await Register(firstname, lastname, email, username, password);
        }
        private async Task<bool> Register(string firstname, string lastname, string email, string username, string password)
        {
            if (string.IsNullOrWhiteSpace(firstname)) return false;
            if (string.IsNullOrWhiteSpace(lastname)) return false;
            if (string.IsNullOrWhiteSpace(email)) return false;
            if (string.IsNullOrWhiteSpace(username)) return false;
            var payload = new
            {
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Username = username,
                Password = password
            };
            var response = await PostAsync("user/register", payload);
            if (response != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private async Task<string> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) return null;
            var payload = new 
            {
                Username = username,
                Password = password
            };
            var response = await PostAsync("user/authenticate", payload);

            if (response != null && response.Data != null)
            {
                var data = JObjectToObject.Convert<LoginResult>(response.Data);
                //var data = response.Data as LoginResult;
                return data.Token;
            }
            else
            {
                return null;
            }


        }

        public void LogOut()
        {
            _storage.DeleteKey(StorageKeys.ACCESS_TOKEN.Value);
        }
    }
}
