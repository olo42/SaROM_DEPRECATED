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
    public event EventHandler LogAdded;

    public void SetOperation(Operation operation)
    {
      this.operation = operation;

      OperationCreated?.Invoke(this, null);
    }

    public Operation GetOperation()
    {
      return this.operation;
    }


  }
}