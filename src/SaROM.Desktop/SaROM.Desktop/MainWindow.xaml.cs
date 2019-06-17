using SaROM.BL;
using SaROM.Desktop.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SaROM.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Login login = null;
        private LoginManager loginManager = null;

        public MainWindow()
        {
            InitializeComponent();
            RegisterLoginControl();
        }

        private void OnSuccessfullLogin(object sender, EventArgs e)
        {
            var overview = new Overview();
            SetContent(overview);
        }

        private void RegisterLoginControl()
        {
            loginManager = new LoginManager();
            login = new Login(loginManager);
            login.LoginSuccessfull += OnSuccessfullLogin;

            SetContent(login);
        }

        private void SetContent(Control overview)
        {
            cc_Main.Content = overview;
        }
    }
}