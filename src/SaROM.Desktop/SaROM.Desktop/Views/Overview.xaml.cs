using System;
using System.Windows.Controls;

namespace SaROM.Desktop.Views
{
  /// <summary>
  /// Interaction logic for OverviewControl.xaml
  /// </summary>
  public partial class Overview : UserControl
  {
    public Overview()
    {
      InitializeComponent();
    }

    public event EventHandler OperationManagement_Click;

    private void Btn_OperationManagement_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      OperationManagement_Click.Invoke(this, null);
    }
  }
}