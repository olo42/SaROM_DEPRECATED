using SaROM.BL;
using SaROM.Desktop.Dialogs;
using SaROM.Entities;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SaROM.Desktop.Controls
{
  /// <summary>
  /// Interaction logic for Operation.xaml
  /// </summary>
  public partial class OperationControl : UserControl
  {
    private List<Button> buttonsDisabledOnMisson;
    private List<Button> buttonsEnabledOnMisson;
    private Operation operation;
    private OperationController operationController;
    private TimeSpan timeSpan;

    public OperationControl(OperationController operationController)
    {
      InitializeComponent();
      InitializeButtonsEnabledOnMisson();
      InitializeButtonsDisabledOnMisson();

      this.operationController = operationController;
      RegisterOperationManagerEvents();
    }

    private void Button_CreateOperation_Click(object sender, RoutedEventArgs e)
    {
      var createOperationDialog = new CreateOperationDialog(this.operationController);
      createOperationDialog.Show();
    }

    private void Button_MissonComlete_Click(object sender, RoutedEventArgs e)
    {
      SetButtonState(false, buttonsEnabledOnMisson);
      SetButtonState(true, buttonsDisabledOnMisson);
    }

    private void Button_RecordMissingPersons_Click(object sender, RoutedEventArgs e)
    {
      var recordMissingPeopleDialog = new RecordMissingPeopleDialog(this.operationController);
      recordMissingPeopleDialog.Show();
    }

    private void DispatcherTimerTick(object sender, EventArgs e)
    {
      this.timeSpan = this.timeSpan.Add(new TimeSpan(0, 0, 1));
      Label_RunTime.Content = this.timeSpan.ToString();
    }

    private void InitializeButtonsDisabledOnMisson()
    {
      buttonsDisabledOnMisson = new List<Button>
      {
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

    private void InitializeDataGrid_Log()
    {
      DataGrid_Log.ItemsSource = this.operation.Logs;

      var dateTime = new DataGridTextColumn();
      dateTime.Header = Properties.Resources.Created;
      dateTime.Binding = new Binding("Created");
      DataGrid_Log.Columns.Add(dateTime);

      var message = new DataGridTextColumn();
      message.Header = Properties.Resources.Message;
      message.Binding = new Binding("Message");
      DataGrid_Log.Columns.Add(message);
    }

    private void OperationController_OperationCreated(object sender, EventArgs e)
    {
      this.operation = operationController.GetOperation();

      SetOperationInformation();
      SetButtonState(true, buttonsEnabledOnMisson);
      SetButtonState(false, buttonsDisabledOnMisson);
      InitializeDataGrid_Log();

      TabItem_Info.IsSelected = true;

      var logMessage = $"Einsatz { this.operation.Identifier} angelegt.";
      Logger.AddLog(logMessage, this.operation.Logs);

      StartRunTimeClock();
    }

    private void RegisterOperationManagerEvents()
    {
      this.operationController.OperationCreated += this.OperationController_OperationCreated;
    }

    private void SetButtonState(bool state, List<Button> buttons)
    {
      foreach (var button in buttons)
      {
        button.IsEnabled = state;
      }
    }

    private void SetOperationInformation()
    {
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

    private void StartRunTimeClock()
    {
      this.timeSpan = new TimeSpan();

      System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
      dispatcherTimer.Tick += new EventHandler(DispatcherTimerTick);
      dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
      dispatcherTimer.Start();
    }
  }
}