using Models.Users;
using Services.Implementations;
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
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserServices _userService;
        public RegisterWindow(IUserServices userServices)
        {
            InitializeComponent();
            _userService = userServices;
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = UsernameBox.Text;
                string email = EmailBox.Text;
                string password = PasswordBox.Password;
                string confirmPassword = ConfirmPasswordBox.Password;
                bool isActive = true;
                DateTime createdAt = DateTime.Now;

                User newUser = new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash = password,
                    IsActive = isActive,
                    CreatedAt = createdAt
                };

                var checkRegister = await _userService.RegisterNewUser(newUser, confirmPassword);
                if (checkRegister != null)
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
