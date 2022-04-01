
using ACRHelix.Feature.ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ProductCatalog.Services
{
  public interface IContentService
  {
    FeaturedProducts GetFeaturedProducts(string Id);

    ProductCategoryList GetProductCategoryList(string Id);
  }
}