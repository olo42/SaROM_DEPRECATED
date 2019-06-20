using SaROM.BL;
using SaROM.Desktop.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SaROM.Desktop.Controls
{
  /// <summary>
  /// Interaction logic for Operation.xaml
  /// </summary>
  public partial class OperationControl : UserControl
  {
    private List<Button> buttonsDisabledOnMisson;
    private List<Button> buttonsEnabledOnMisson;
    private OperationManager operationManager;

    public OperationControl(OperationManager operationManager)
    {
      InitializeComponent();

      this.operationManager = operationManager;
      this.operationManager.OperationCreated += this.OperationManager_OperationCreated;

      InitializeButtonsEnabledOnMisson();
      InitializeButtonsDisabledOnMisson();
    }

    private void OperationManager_OperationCreated(object sender, EventArgs e)
    {
      SetOperationInformation();
      SetIsEnabled(true, buttonsEnabledOnMisson);
      SetIsEnabled(false, buttonsDisabledOnMisson);

      TabItem_Info.IsSelected = true;
    }

    private void Button_CreateMisson_Click(object sender, RoutedEventArgs e)
    {
      var run = new CreateOperationDialog(operationManager);
      run.Show();
    }

    private void Button_MissonComlete_Click(object sender, RoutedEventArgs e)
    {
      SetIsEnabled(false, buttonsEnabledOnMisson);
      SetIsEnabled(true, buttonsDisabledOnMisson);
    }

    private void InitializeButtonsDisabledOnMisson()
    {
      buttonsDisabledOnMisson = new List<Button>
      {
        Button_Archive,
        Button_CreateMisson
      };
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

    private void SetIsEnabled(bool state, List<Button> buttons)
    {
      foreach (var button in buttons)
      {
        button.IsEnabled = state;
      }
    }

    private void SetOperationInformation()
    {
      var operation = operationManager.GetOperation();

      Label_Identifier.Content = operation.Identifier;
      Label_MissionOrder.Content = operation.MissionOrder;
      Label_PlaceOfAction.Content = operation.PlaceOfAction;
      Label_AlertedBy.Content = operation.AlertedBy;
      Label_TimeOfAlterting.Content = operation.TimeOfAlterting;
      Label_PoliceContact.Content = operation.PoliceContact;
      Label_OperationManager.Content = operation.OperationManager;
      Label_HeadquarterContact.Content = operation.HeadquarterContact;
      Label_Secretary.Content = operation.Secretary;
    }
  }
}