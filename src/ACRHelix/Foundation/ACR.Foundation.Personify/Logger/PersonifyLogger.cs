using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Sitecore.Diagnostics;

namespace ACR.Foundation.Personify.Logger
{
  public static class PersonifyLogger
  {
    private const string LoggerName = "Personify";

    private static ILog logger;
    public static ILog Logger
    {
      get
      {
        if (logger == null)
        {
          logger = LoggerFactory.GetLogger(LoggerName);
        }
        return logger;
      }
    }

  }
}