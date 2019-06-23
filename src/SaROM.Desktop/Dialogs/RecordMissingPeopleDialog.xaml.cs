using SaROM.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SaROM.Desktop.Dialogs
{
  /// <summary>
  /// Interaction logic for RecordMissingPeopleDialog.xaml
  /// </summary>
  public partial class RecordMissingPeopleDialog : Window
  {
    private OperationController operationController;

    public RecordMissingPeopleDialog(OperationController operationController)
    {
      InitializeComponent();
      this.operationController = operationController;
    }
  }
}
