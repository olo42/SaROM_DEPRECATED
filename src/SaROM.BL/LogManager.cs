using SaROM.Entities;
using System;

namespace SaROM.BL
{
    public class LogManager
    {
        private Operation operation;

        public EventHandler MessageLogged;

        public LogManager(Operation operation)
        {
            this.operation = operation;
        }
        public void AddToLog(string message)
        {
            LogMessage logMessage = new LogMessage
            {
                Created = DateTime.Now,
                Message = message

            };

            this.operation.AddToLog(logMessage);
            this.MessageLogged.Invoke(this, null);
        }
    }
}