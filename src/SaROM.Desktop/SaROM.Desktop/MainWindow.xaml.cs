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
      // RegisterLoginControl();

      // Avoid login every time during development
      var operation = new Operation();
      SetContent(operation); 
    }

    private void OnSuccessfullLogin(object sender, EventArgs e)
    {
      var overview = new Overview();
      overview.OperationManagement_Click += CallOperationManagement;

      SetContent(overview);
    }

    private void CallOperationManagement(object sender, EventArgs e)
    {
      var operation = new Operation();

      SetContent(operation);
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