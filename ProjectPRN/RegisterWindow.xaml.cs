using DrugPreventionSystem.DataAccess.Models;
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
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserServices _userServices;

        public RegisterWindow()
        {
        }

        public RegisterWindow(IUserServices userServices)
        {
            InitializeComponent();
            _userServices = userServices;
        }

        private async Task RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string newEmail = EmailBox.Text;
                string newUsername = UsernameBox.Text;
                string password = PasswordBox.Password;
                string confirmPassword = ConfirmPasswordBox.Password;

                if (string.IsNullOrWhiteSpace(newEmail) || string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                User newUser  = new User
                {
                    UserId = Guid.NewGuid(),
                    Email = newEmail,
                    Username = newUsername,
                    PasswordHash = password,// temp password , hash it on repository
                    RoleId = 3,// member role
                    IsActive = true,
                    EmailVerified = false,
                    CreatedAt = DateTime.Now
                };
                var user = await _userServices.Register(newUser);
                MessageBox.Show("Registration successful.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
