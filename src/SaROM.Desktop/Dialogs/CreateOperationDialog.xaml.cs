using SaROM.BL;
using SaROM.Entities;
using System;
using System.Windows;

namespace SaROM.Desktop.Dialogs
{
  public partial class CreateOperationDialog : Window
  {
    OperationController operationManager = null;
    public CreateOperationDialog(OperationController operationManager)
    {
      InitializeComponent();

      this.operationManager = operationManager;
      this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
      this.ContentRendered += this.CreateOperationDialog_ContentRendered;
    }

    private void CreateOperationDialog_ContentRendered(object sender, System.EventArgs e)
    {
      TextBox_TimeOfAlterting.Text = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}"; 
    }

    private void Button_Cancel_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void Button_Save_Click(object sender, RoutedEventArgs e)
    {
      Operation operation = new Operation();
      operation.Identifier = TextBox_Identifier.Text;
      operation.MissionOrder = TextBox_MissionOrder.Text;
      operation.PlaceOfAction = TextBox_PlaceOfAction.Text;
      operation.AlertedBy = TextBox_AlertedBy.Text;
      operation.TimeOfAlterting = TextBox_TimeOfAlterting.Text;
      operation.PoliceContact = TextBox_PoliceContact.Text;
      operation.OperationManager = TextBox_OperationManager.Text;
      operation.HeadquarterContact = TextBox_HeadquarterContact.Text;
      operation.Secretary = TextBox_Secretary.Text;

      operationManager.SetOperation(operation);

      this.Close();
    }
  }
}