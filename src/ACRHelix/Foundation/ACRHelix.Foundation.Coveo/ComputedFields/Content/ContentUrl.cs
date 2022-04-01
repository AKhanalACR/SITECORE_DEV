using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using ACR.Foundation.Personify.Models.Products;
using Sitecore.Data.Fields;
using Sitecore.Layouts;
using Sitecore.Sites;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class ContentUrl : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType
    {
      get
      {
        return CoveoConstants.CoveoFieldTypes.CoveoString;
      }
      set
      {

      }
    }

    public object ComputeFieldValue(IIndexable indexable)
    {
      SitecoreIndexableItem indexableItem = indexable as SitecoreIndexableItem;
      if (indexableItem != null)
      {
        string templateId = indexableItem.Item.TemplateID.ToString();

        //using (new SiteContextSwitcher(SiteContext.GetSite("website")))
        //{
        //  Sitecore.Links.UrlOptions options = Sitecore.Links.UrlOptions.DefaultOptions;
        //  options.Site = Sitecore.Configuration.Factory.GetSite("website");
        //  options.AlwaysIncludeServerUrl = false;

          //this is being commented out as testimonials have now layout to view the items - 5/10/2018

          //if (templateId == "{F8C25D64-FEA9-49A2-A763-78DF7A277FF8}") //testimonial
          //{
          //  var testimonialPage = indexableItem.Item.Database.GetItem("{7E849CBA-2E97-495A-B339-272537446D43}");
          //  if (testimonialPage != null)
          //  {
          //    return FixLink(Sitecore.Links.LinkManager.GetItemUrl(testimonialPage));
          //  }
          //}
          if (templateId == "{61638935-4C4D-4423-A446-3705DF33905B}") //toolkit content
          {
            string fullPath = indexableItem.Item.Paths.FullPath;
            int localIndex = fullPath.LastIndexOf("/Local Content/");
            if (localIndex > 0)
            {
              var contentPage = indexableItem.Item.Database.GetItem(fullPath.Substring(0, localIndex));
              if (contentPage != null)
              {
                var finalLayoutField = new LayoutField(contentPage.Fields[Sitecore.FieldIDs.FinalLayoutField]);
                if (finalLayoutField != null)
                {
                  var finalLayoutDefinition = LayoutDefinition.Parse(finalLayoutField.Value);
                  string xml = finalLayoutDefinition.ToXml();
                  if (xml.IndexOf(indexableItem.Item.ID.ToString(), StringComparison.OrdinalIgnoreCase) > 0)
                  {
                    return FixLink(Sitecore.Links.LinkManager.GetItemUrl(contentPage) + "#" + indexableItem.Item.ID.ToShortID().ToString());
                  }
                }
              }
            }
            return null;
          }
        if (templateId == "{0CEA0658-0891-4FE2-897A-79FF8BB21523}")
        {
          if (!string.IsNullOrWhiteSpace(indexableItem.Item.Fields["Link Override"].Value))
          {
            return indexableItem.Item.Fields["Link Override"].Value;
          }
          else
          {
            return null;
          }
        }
          /*  Biographies disabled from search results
          if (templateId == "{DF09F9E1-4A1E-4A94-A74B-8A3FA8FCBFA4}") //biography
          {
            string fullPath = indexableItem.Item.Paths.FullPath;
            int localIndex = fullPath.LastIndexOf("/Local Content/");
            if (localIndex > 0)
            {
              var contentPage = indexableItem.Item.Database.GetItem(fullPath.Substring(0, localIndex));
              if (contentPage != null)
              {
                var finalLayoutField = new LayoutField(contentPage.Fields[Sitecore.FieldIDs.FinalLayoutField]);
                if (finalLayoutField != null)
                {
                  var finalLayoutDefinition = LayoutDefinition.Parse(finalLayoutField.Value);
                  string xml = finalLayoutDefinition.ToXml();
                  if (xml.IndexOf(indexableItem.Item.Parent.ID.ToString(), StringComparison.OrdinalIgnoreCase) > 0)
                  {
                    return Sitecore.Links.LinkManager.GetItemUrl(contentPage,options);
                  }
                }
              }
            }
          }*/

          if (templateId == ProductStubItem.TemplateID)
          {
            ProductStubs.ProductUrl productUrl = new ProductStubs.ProductUrl();
            return productUrl.ComputeFieldValue(indexable);
          }
                //if (templateId == "{97021C60-4F16-47D3-B256-0D2AA6B10747}")
                //{
                //    if (!string.IsNullOrWhiteSpace(indexableItem.Item.Fields["Resource Link"].Value))
                //    {
                //        LinkField lf = indexableItem.Item.Fields["Resource Link"];
                //        return lf.Url;
                //    }
                //    else
                //    {
                //        return null;
                //    }
                //}
                if (templateId == "{2EAD1608-9E8C-444F-AF66-766578E687F8}")
                {
                    if (!string.IsNullOrWhiteSpace(indexableItem.Item.Fields["Resource Link"].Value))
                    {
                        string value = indexableItem.Item.Fields[SitecoreConstants.Templates.IdeasYoutubeVideoResources.Fields.IsYoutubeVideo].Value;
                        if (value != "1")
                        {
                            LinkField lf = indexableItem.Item.Fields["Resource Link"];
                            return lf.Url;
                        }
                        else
                        {
                            return FixLink(Sitecore.Links.LinkManager.GetItemUrl(indexableItem.Item));
                        }
                    }
                }
                return FixLink(Sitecore.Links.LinkManager.GetItemUrl(indexableItem.Item));

        //}
      }
      return null;
    }

    private string FixLink(string link)
    {            
            string match = "/sitecore/shell/ACR";
            string match2 = "/sitecore/shell/DSI";
            string match3 = "/sitecore/shell/ImageWisely";
            string match4 = "/sitecore/shell/Ideas";
            string match5 = "/sitecore/shell/RADPAC";
            string match6 = "/sitecore/shell/DECAMP";
            string match1 = "/sitecore/shell";
            int index = link.IndexOf(match, StringComparison.OrdinalIgnoreCase);
            if (index == 0)
            {
              link = link.Substring(match.Length);
            }

            index = link.IndexOf(match2, StringComparison.OrdinalIgnoreCase);
            if (index == 0)
            {
                link = link.Substring(match2.Length);
            }

            index = link.IndexOf(match3, StringComparison.OrdinalIgnoreCase);
            if (index == 0)
            {
                link = link.Substring(match3.Length);
            }
            index = link.IndexOf(match4, StringComparison.OrdinalIgnoreCase);
            if (index == 0)
            {
                link = link.Substring(match4.Length);
            }
            index = link.IndexOf(match5, StringComparison.OrdinalIgnoreCase);
            if (index == 0)
            {
                link = link.Substring(match5.Length);
            }
            index = link.IndexOf(match6, StringComparison.OrdinalIgnoreCase);
            if (index == 0)
            {
              link = link.Substring(match6.Length);
            }
            index = link.IndexOf(match1, StringComparison.OrdinalIgnoreCase);
            if (index == 0)
            {
              link = link.Substring(match1.Length);
            }

            return link;
    }
  }
}