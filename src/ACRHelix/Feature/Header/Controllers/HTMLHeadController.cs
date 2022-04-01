using ACRHelix.Feature.HTMLHead.Services;
using ACRHelix.Feature.HTMLHead.ViewModels;
using Sitecore.Mvc.Presentation;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Foundation.Assets.Services;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System;

namespace ACRHelix.Feature.HTMLHead
{
  public class HTMLHeadController : Controller
  {
    private readonly IContentService _contentService;

    public HTMLHeadController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult HTMLHead()
    {
      var viewModel = new HTMLHeadViewModel();

      var item = Sitecore.Context.Item;
      if (item != null)
      {
        viewModel.Id = item.ID.ToGuid(); ;
        viewModel.CanonicalURL = item.GetCanonicalUrl();

      }
      return View(viewModel);
    }


    }

    /*
    public ViewResult FooterScripts()
    {
      var viewModel = new HTMLHeadViewModel();
      var dataSource = "{46B9DC2B-7F03-4092-958C-77D051C30142}"; //ACR root item ID
      if (!String.IsNullOrEmpty(dataSource))
      {
        var htmlHeadContent = _contentService.GetHTMLHeadContent(dataSource);
        if (htmlHeadContent != null)
        {
          viewModel.Javascript = htmlHeadContent.Javascript;         
        }
      }
      viewModel.JavascriptAssets = RenderAssetsService.Current.RenderScript(Sitecore.Foundation.Assets.Models.ScriptLocation.Body).ToString();
      return View(viewModel);
    }*/
}