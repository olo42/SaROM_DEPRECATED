using SaROM.Entities;
using System;
using System.Collections.Generic;

namespace SaROM.BL
{
  public class OperationController
  {
    private Operation operation;

    public OperationController()
    {
    }

    public event EventHandler OperationCreated;
    public event EventHandler LogUpdated;

    public void SetOperation(Operation operation)
    {
      this.operation = operation;

      OperationCreated?.Invoke(this, EventArgs.Empty);
    }

    public Operation GetOperation()
    {
      return this.operation;
    }


  }
}