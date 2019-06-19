﻿using SaROM.BL;
using SaROM.Entities;
using System.Windows;

namespace SaROM.Desktop.Dialogs
{
  public partial class CreateOperationDialog : Window
  {
    OperationManager operationManager = null;
    public CreateOperationDialog(OperationManager operationManager)
    {
      InitializeComponent();

      this.operationManager = operationManager;
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

      operationManager.CreateOperation(operation);

      this.Close();
    }
  }
}