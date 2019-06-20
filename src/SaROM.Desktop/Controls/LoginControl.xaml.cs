using SaROM.BL;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SaROM.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        private LoginManager loginManager;

        public LoginControl(LoginManager loginManager)
        {
            InitializeComponent();

            this.loginManager = loginManager;
        }

        public event EventHandler LoginSuccessfull;

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            var username = GetUsername();
            var password = GetPassword();

            if (loginManager.IsValidLogin(username, password))
            {
                LoginSuccessfull?.Invoke(this, null);
            }
            else
            {
                ShowInvalidLogin();
            };
        }

        private string GetPassword()
        {
            return tb_Password.Password;
        }

        private string GetUsername()
        {
            return this.tb_UserName.Text;
        }

        private void ShowInvalidLogin()
        {
            lbl_InvalidLogin.Visibility = Visibility.Visible;
        }
    }
}