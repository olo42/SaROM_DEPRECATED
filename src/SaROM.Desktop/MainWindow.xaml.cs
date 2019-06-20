using SaROM.BL;
using SaROM.Desktop.Controls;
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
    private LoginControl loginControl = null;
    private LoginManager loginManager = null;
    private OperationControl operationControl = null;
    private OperationManager operationManager = null;

    public MainWindow()
    {
      this.operationManager = new OperationManager();

      InitializeComponent();
      InitializeLoginControl();
      InitializeOperationControl();

      // Avoid login every time during development
      // ShowLoginControl();

      SetContent(this.operationControl);
    }

    private void InitializeLoginControl()
    {
      loginManager = new LoginManager();
      loginControl = new LoginControl(loginManager);
      loginControl.LoginSuccessfull += OnSuccessfullLogin;
    }

    private void InitializeOperationControl()
    {
      operationControl = new OperationControl(operationManager);
    }

    private void OnSuccessfullLogin(object sender, EventArgs e)
    {
      SetContent(operationControl);
    }

    private void SetContent(Control overview)
    {
      cc_Main.Content = overview;
    }

    private void ShowLoginControl()
    {
      SetContent(loginControl);
    }
  }
}