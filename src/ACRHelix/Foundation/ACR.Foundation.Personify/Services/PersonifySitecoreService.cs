using ACR.Foundation.Personify.Models.Base;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.Models.Taxonomy;
using Glass.Mapper.Sc;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Services
{
  public class PersonifySitecoreService
  {
    private readonly ISitecoreService _sitecoreService;

    public PersonifySitecoreService()
    {
      _sitecoreService = new SitecoreService(Sitecore.Context.Database);
    }

    public PersonifySitecoreService(string database)
    {
      _sitecoreService = new SitecoreService(database);
    }

    public ProductStubItem GetProductStub(Item item)
    {
      return _sitecoreService.Cast<ProductStubItem>(item);
    }

    public PersonifyTaxonomyItem GetPersonifyTaxonomyItem(Item item)
    {
      return _sitecoreService.Cast<PersonifyTaxonomyItem>(item);
    }

    public T CreateUpdateItem<T>(T item) where T : class, IBasePersonifyItem
    {
      using (new SecurityDisabler())
      {
        if (item.ID.IsNull)
        {
          item.Name = ItemUtil.ProposeValidItemName(item.Name);
          item = _sitecoreService.Create(item.Parent, item);
        }
        else
        {
          item.Name = ItemUtil.ProposeValidItemName(item.Name);
          _sitecoreService.Save(item);
        }
        return item;
      }
    }

    public void DeleteItem<T>(T item) where T : class, IBasePersonifyItem
    {
      using (new SecurityDisabler())
      {
        _sitecoreService.Delete(item);
      }
    }

  }
}