using log4net;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.ExpressUrls.Logger
{
  public class ExpressUrlLogger
  {
    private const string LoggerName = "ExpressUrlLogger";

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