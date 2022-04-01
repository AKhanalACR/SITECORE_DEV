using System.Web.Mvc;
using System.Web.Routing;
using Sitecore.Pipelines;

namespace ACRHelix.Feature.Navigation.Pipelines
{
  public class SitemapRoute : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
  {
    public override void Process(PipelineArgs args)
    {
      RouteTable.Routes.MapRoute("SitemapXml", "sitemap.xml", new { controller = "Navigation", action = "SitemapXml" }, new[] { "ACRHelix.Feature.Navigation" });
      RouteTable.Routes.MapRoute("RobotsTxt", "robots.txt", new { controller = "Navigation", action = "RobotsTxt" }, new[] { "ACRHelix.Feature.Navigation" });

    }
  }
}