
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.ProductCatalog.Models;

namespace ACRHelix.Feature.ProductCatalog.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }

    public FeaturedProducts GetFeaturedProducts(string Id)
    {
      return _repository.GetContentItem<FeaturedProducts>(Id);
    }

    public ProductCategoryList GetProductCategoryList(string Id)
    {
      return _repository.GetContentItem<ProductCategoryList>(Id);
    }
  }
}