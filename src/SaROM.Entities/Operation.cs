using System.Collections.Generic;

namespace SaROM.Entities
{
    public class Operation
    {
        private List<LogMessage> logs;

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
        
        public void AddToLog(LogMessage logMessage)
        {
            this.logs.Add(logMessage);
        }
    }
}