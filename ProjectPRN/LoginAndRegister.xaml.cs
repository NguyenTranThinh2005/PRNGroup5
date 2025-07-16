using Models.Users;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentation
{
   
    public partial class LoginAndRegister : Window
    {
        private readonly IUserServices _userService;
        public LoginAndRegister(IUserServices userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = EmailBox.Text;
                string password = PasswordBox.Password;

                if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please enter your email and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var exitUser =  await _userService.Checklogin(email, password);
                if (exitUser != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Invalid email or password. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)

            {

                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void RegisterText_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(_userService);
            registerWindow.Show();
            this.Close();
        }
    }
}
