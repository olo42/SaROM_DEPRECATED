using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SaROM.Desktop.Views
{
  /// <summary>
  /// Interaction logic for Operation.xaml
  /// </summary>
  public partial class Operation : UserControl
  {
    private List<Button> buttonsEnabledOnMisson;
    private List<Button> buttonsDisabledOnMisson;

    public Operation()
    {
      InitializeComponent();

      InitializeButtonsEnabledOnMisson();
      InitializeButtonsDisablenOnMisson();
    }

    private void Button_CreateMisson_Click(object sender, RoutedEventArgs e)
    {
      SetIsEnabled(true, buttonsEnabledOnMisson);
      SetIsEnabled(false, buttonsDisabledOnMisson);

      var run = new RunMisson();
      run.Show();
    }

    private void Button_MissonComlete_Click(object sender, RoutedEventArgs e)
    {
      SetIsEnabled(false, buttonsEnabledOnMisson);
      SetIsEnabled(true, buttonsDisabledOnMisson);
    }

    private void InitializeButtonsEnabledOnMisson()
    {
      buttonsEnabledOnMisson = new List<Button>
      {
        Button_RecordMissingPersons,
        Button_RecordEmergencyForces,
        Button_MassagesAndActions,
        Button_StandartActions,
        Button_Print,
        Button_MissonComlete
      };
    }

    private void InitializeButtonsDisablenOnMisson()
    {
      buttonsDisabledOnMisson = new List<Button>
      {
        Button_Archive,
        Button_CreateMisson
      };
    }

    private void SetIsEnabled(bool state, List<Button> buttons)
    {
      foreach (var button in buttons)
      {
        button.IsEnabled = state;
      }
    }
  }
}