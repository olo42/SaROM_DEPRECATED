using SaROM.Entities;
using System;
using System.Collections.Generic;

namespace SaROM.BL
{
  public class OperationManager
  {
    private List<Person> missingPeople;

    private Operation operation;

    public OperationManager()
    {
      this.missingPeople = new List<Person>();
    }

    public event EventHandler MissingPersonAdded;
    public event EventHandler OperationCreated;

    public void AddMissingPerson(Person person)
    {
      this.missingPeople.Add(person);

      MissingPersonAdded.Invoke(this, null);
    }

    public void CreateOperation(Operation operation)
    {
      this.operation = operation;

      OperationCreated?.Invoke(this, null);
    }

    public List<Person> GetMissingPerson()
    {
      return this.missingPeople;
    }

    public Operation GetOperation()
    {
      return this.operation;
    }
  }
}