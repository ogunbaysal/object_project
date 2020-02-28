using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace client.Administrator.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    
    public partial class LoginPage : Window
    {
        protected string Username { get; set; }
        protected string Password { get; set; }
        public LoginPage()
        {
            InitializeComponent();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.Password = ((PasswordBox)sender).Password;
        }

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Username = ((TextBox)sender).Text;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
