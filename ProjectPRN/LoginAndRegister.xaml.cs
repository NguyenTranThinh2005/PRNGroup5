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
    /// Interaction logic for LoginAndRegister.xaml
    /// </summary>
    public partial class LoginAndRegister : Window
    {
        private readonly IUserServices _userService;
        public LoginAndRegister(IUserServices userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async Task LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = EmailBox.Text;
                string password = PasswordBox.Password;

                if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("bạn hãy nhập email và password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var exitUser = await _userService.Login(email, password);
                if (exitUser != null)
                {
                    MessageBox.Show("Đăng nhập thành công !", "Thành công ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(" email và password không đúng . Hãy nhập lại đi .", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (exitUser.RoleId == 1)
                {
                    // Admin page
                    MessageBox.Show("Bạn đã đăng nhập với tư cách là quản trị viên.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (exitUser.RoleId == 2)
                {
                    // Manager page
                    MessageBox.Show("Bạn đã đăng nhập với tư cách là quản lý.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (exitUser.RoleId == 3)
                {
                    // memeber page
                    MessageBox.Show("Bạn đã đăng nhập với tư cách là thành viên.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void RegisterText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.ShowDialog();
            this.Close();
        }
    }
}
