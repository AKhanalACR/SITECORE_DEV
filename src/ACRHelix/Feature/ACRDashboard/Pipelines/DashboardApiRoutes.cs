using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ACRHelix.Feature.ACRDashboard.Pipelines
{
  public class DashboardApiRoutes : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
  {
    public override void Process(PipelineArgs args)
    {
      RouteTable.Routes.MapRoute("DeleteBookmark", "MyACRDashboard/DeleteBookmark/{id}", new
      { controller = "ACRDashboard", action = "DeleteBookmark" }, new[] { "ACRHelix.Feature.ACRDashboard" });

      RouteTable.Routes.MapRoute("AddReccomendedArticle", "MyACRDashboard/AddReccomendedArticle/{id}", new
      { controller = "ACRDashboard", action = "AddReccomendedArticle" }, new[] { "ACRHelix.Feature.ACRDashboard" });

      RouteTable.Routes.MapRoute("AddBookmark", "MyACRDashboard/AddBookmark/{id}", new
      { controller = "ACRDashboard", action = "AddBookmark" }, new[] { "ACRHelix.Feature.ACRDashboard" });



    }
  }
}