using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile.DataServices.Interface
{
    public interface IAuthenticationService
    {
        bool IsLoggedIn();

        Task<bool> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(string firstname, string lastname, string email, string username, string password);

        void LogOut();
    }
}
