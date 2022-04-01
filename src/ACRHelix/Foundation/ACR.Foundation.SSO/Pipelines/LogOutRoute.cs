using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace ACR.Foundation.SSO.Pipelines
{
  public class LogOutRoute : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
  {
    public override void Process(PipelineArgs args)
    {
      RouteTable.Routes.MapRoute("LogOut", "LogOut", new { controller = "SSOLogOut", action = "LogOut" }, new[] { "ACR.Foundation.SSO" });
    }
  }
}