using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SaROM.Entities
{
  public class Operation
  {
    ObservableCollection<LogItem> logs = null;

    public Operation()
    {
      this.logs = new ObservableCollection<LogItem>(); 
    }

    public ObservableCollection<LogItem> Logs
    {
      get { return this.logs;  }
    }

    public string AlertedBy { get; set; }

    public string HeadquarterContact { get; set; }

    public string Identifier { get; set; }

    public List<Person> MissingPeople { get; set; }

    public string MissionOrder { get; set; }

    public string OperationManager { get; set; }

    public string PlaceOfAction { get; set; }

    public string PoliceContact { get; set; }

    public string Secretary { get; set; }

    public string TimeOfAlterting { get; set; }
  }
}