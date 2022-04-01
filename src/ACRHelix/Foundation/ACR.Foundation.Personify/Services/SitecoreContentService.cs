using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACR.Foundation.Personify.Models;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;
using ACRHelix.Foundation.Repository.Content;
using Sitecore.Data;
using Glass.Mapper.Sc;
using Sitecore.SecurityModel;
using Sitecore.Data.Items;
using ACR.Foundation.Personify.Models.Taxonomy.RLI;
using ACR.Foundation.Personify.Models.Base;
using ACR.Foundation.Personify.Constants;

namespace ACR.Foundation.Personify.Services
{
  public class SitecoreContentService
  {
    private readonly IContentRepository _repository;

    public SitecoreContentService()
    {
      _repository = new SitecoreContentRepository();
     
    }

    public SitecoreContentService(string database)
    {
      _repository = new SitecoreContentRepository(database);
     
    }

    public TaxonomyFolder GetTaxonomyFolder(ID Id)
    {
      return _repository.GetContentItem<TaxonomyFolder>(Id);
    }

    public ProductStubItem GetProductStub(ID Id)
    {
      return _repository.GetContentItem<ProductStubItem>(Id);
    }
   

    public AcrProtectedContent GetAcrProtectedContentItem(ID Id)
    {
      return _repository.GetContentItem<AcrProtectedContent>(Id);
    }

    public ProductRootFolder GetProductRootFolder(ID Id)
    {
      return _repository.GetContentItem<ProductRootFolder>(Id);
    }

    public ProductSubsytemFolder GetProductSubsytemFolder(ID Id)
    {
      return _repository.GetContentItem<ProductSubsytemFolder>(Id);
    }

    public ProductClassFolder GetProductClassFolder(ID Id)
    {
      return _repository.GetContentItem<ProductClassFolder>(Id);
    }

    public PersonifyTaxonomyItem GetTaxonomyItem(ID Id)
    {
      return _repository.GetContentItem<PersonifyTaxonomyItem>(Id);
    }

    public RLIPersonifyFolder GetRLIPersonifyFolder(ID id)
    {
     
      return _repository.GetContentItem<RLIPersonifyFolder>(id);
    }

  }
}