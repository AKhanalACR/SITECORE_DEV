using log4net;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo.Logger
{
  public static class CustomCoveoLogger
  {
    private const string LoggerName = "CustomCoveo";

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