using ACRHelix.Feature.NetworkOfWebsites.Services;
using Sitecore.Mvc.Presentation;
using System;
using System.Web.Mvc;

namespace ACRHelix.Feature.NetworkOfWebsites
{
  public class NetworkOfWebsitesController : Controller
  {
    private readonly IContentService _contentService;

    public NetworkOfWebsitesController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult NetworkOfWebsites()
    {
      var viewModel = new Models.NetworkOfWebsites();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var NetworkOfWebsitesContent = _contentService.GetNetworkOfWebsitesContent(RenderingContext.Current.Rendering.DataSource);
        if (NetworkOfWebsitesContent != null)
        {
          viewModel = NetworkOfWebsitesContent;
        }
      }
      return View(viewModel);
    }
  }
}