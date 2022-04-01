using ACRHelix.Foundation.CustomCoveo.ComputedFields.Base;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.ProductStubs
{
  public class ProductClass : ProductStubComputedField, IComputedIndexField
  {
    public ProductClass()
    {
      FieldID = new Sitecore.Data.ID(SitecoreConstants.Templates.ProductStub.Fields.ProductClass);
    }
  }
}