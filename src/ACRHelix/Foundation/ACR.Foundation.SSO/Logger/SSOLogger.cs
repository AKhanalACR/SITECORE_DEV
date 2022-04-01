using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Sitecore.Diagnostics;

namespace ACR.Foundation.SSO.Logger
{
  public class SSOLogger
  {
    private const string LoggerName = "SSO";

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