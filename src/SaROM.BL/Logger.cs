using SaROM.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SaROM.BL
{
  public static class Logger
  {
    public static void AddLog(string message, ObservableCollection<LogItem> log)
    {
      LogItem logItem = new LogItem
      {
        Created = DateTime.Now,
        Message = message
      };

      log.Add(logItem);
    }
  }
}