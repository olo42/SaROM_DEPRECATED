using System.Collections.ObjectModel;

namespace SaROM.Entities
{
  public class Operation
  {
    private ObservableCollection<LogItem> logs = null;
    private ObservableCollection<Person> missingPeople = null;

    public Operation()
    {
      this.logs = new ObservableCollection<LogItem>();
      this.missingPeople = new ObservableCollection<Person>();
    }

    public string AlertedBy { get; set; }

    public string HeadquarterContact { get; set; }

    public string Identifier { get; set; }

    public ObservableCollection<LogItem> Logs
    {
      get { return this.logs; }
    }

    public ObservableCollection<Person> MissingPeople
    {
      get { return this.missingPeople; }
    }

    public string MissionOrder { get; set; }

    public string OperationManager { get; set; }

    public string PlaceOfAction { get; set; }

    public string PoliceContact { get; set; }

    public string Secretary { get; set; }

    public string TimeOfAlterting { get; set; }
  }
}