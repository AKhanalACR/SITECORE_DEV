using Sitecore.Pipelines;
using System.Web.Mvc;
using System.Web.Routing;

namespace ACR.Foundation.PersonifyCartService.Pipelines
{
  public class PersonifyCartRoute : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
  {
    public override void Process(PipelineArgs args)
    {
      RouteTable.Routes.MapRoute("PersonifyCartApi", "personifycart/addtocart/{id}", new
      { controller = "PersonifyCartApi", action = "AddProductToCart" }, new[] { "ACR.Foundation.PersonifyCartService" });

      RouteTable.Routes.MapRoute("PersonifySaveLaterApi", "personifycart/saveforlater/{id}", new
      { controller = "PersonifyCartApi", action = "SaveForLater" }, new[] { "ACR.Foundation.PersonifyCartService" });

      RouteTable.Routes.MapRoute("PersonifyCartCountApi", "personifycart/cartcount", new
      { controller = "PersonifyCartApi", action = "GetShoppingCartCount" }, new[] { "ACR.Foundation.PersonifyCartService" });
    }
  }
}