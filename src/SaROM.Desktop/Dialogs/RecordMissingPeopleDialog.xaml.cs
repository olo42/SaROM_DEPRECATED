using SaROM.BL;
using SaROM.Entities;
using System.Windows;

namespace SaROM.Desktop.Dialogs
{
  public partial class RecordMissingPeopleDialog : Window
  {
    private OperationController operationController;

    public RecordMissingPeopleDialog(OperationController operationController)
    {
      InitializeComponent();
      this.operationController = operationController;
    }

    private void Button_Cancel_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void Button_Save_Click(object sender, RoutedEventArgs e)
    {
      Person missingPerson = this.CreateMissingPerson();

      var operation = this.operationController.GetOperation();
      operation.MissingPeople.Add(missingPerson);

      this.Close();
    }

    private Person CreateMissingPerson()
    {
      var missingPerson = new Person();

      missingPerson.Name = TextBox_Name.Text;
      missingPerson.Address = TextBox_Adddress.Text;
      missingPerson.Age = TextBox_YearOfBirth_Age.Text;
      missingPerson.Gender = TextBox_Gender.Text;
      missingPerson.Height = TextBox_Size.Text;
      missingPerson.Weight = TextBox_Weight.Text;
      missingPerson.HairColor = TextBox_HairColor.Text;
      missingPerson.Clothes = TextBox_Clothes.Text;
      missingPerson.SpecialProperties = TextBox_SpecialProperties.Text;
      missingPerson.Diseases = TextBox_Diseases.Text;
      missingPerson.Medicals = TextBox_Medicals.Text;
      missingPerson.AdditionalInformation = TextBox_AdditionalInformation.Text;

      return missingPerson;
    }
  }
}