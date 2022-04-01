using ACRHelix.Feature.ProductCatalog.Models;
using ACRHelix.Feature.ProductCatalog.Services;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.ProductCatalog
{
  public class ProductCatalogController : Controller
  {
    private readonly IContentService _contentService;

    public ProductCatalogController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult FeaturedProducts()
    {
      var viewModel = new FeaturedProducts();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var model = _contentService.GetFeaturedProducts(dataSource);
        if (model != null)
        {
          viewModel = model;
        }
      }
      return View(viewModel);
    }

    public ViewResult ProductCategories()
    {
      var viewModel = new ProductCategoryList();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var model = _contentService.GetProductCategoryList(dataSource);
        if (model != null)
        {
          viewModel = model;
        }
      }
        return View(viewModel);
    }

    public ViewResult ProductDetail()
    {
      var viewModel = new ACR.Foundation.Personify.Models.Products.ProductStubItem();
      ACR.Foundation.Personify.Services.SitecoreContentService _contentService = new ACR.Foundation.Personify.Services.SitecoreContentService();
      var product = _contentService.GetProductStub(Sitecore.Context.Item.ID);
      if (product != null)
      {
        viewModel = product;
      }
      return View(viewModel);
    }
  
  }
}