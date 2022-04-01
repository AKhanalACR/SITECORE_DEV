using ACRHelix.Feature.Navigation.Models;
using ACRHelix.Foundation.Repository.Content;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACRHelix.Feature.Navigation.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      if (Sitecore.Context.Database != null)
      {
        _repository = repository;
      }
      else
      {
        _repository = new SitecoreContentRepository("web");
      }
    }
    public ILinkMenu GetLinkMenuContent(string contentGuid)
    {
      return _repository.GetContentItem<ILinkMenu>(contentGuid);
    }
    public IBreadcrumbs GetBreadcrumbsContent(string contentGuid)
    {
        Database database = Sitecore.Context.Database;
        Item currentPage = database.GetItem(contentGuid);

        List<Link> links = new List<Link>();
        
        while(currentPage != null)
        {
            if (currentPage.TemplateName == "Site Root")
            {
                break;
            }
            else if (currentPage.IsDerived(Constants.Templates.Navigable.ID) && currentPage.Fields["Short Title"] != null)
            {
                    links.Add(new Link { Url = LinkManager.GetItemUrl(currentPage), Text = currentPage.Fields["Short Title"].ToString() });        
            }            
            
            currentPage = currentPage.Parent;
        }

        links.Reverse();

        Breadcrumbs breadcrumbs = new Breadcrumbs
        {
            Id = new ID(contentGuid),
            Links = links
        };

        return breadcrumbs;
    }

    public INavigationRoot GetMainNavigationContent()
    {
      string itemId = "{46B9DC2B-7F03-4092-958C-77D051C30142}"; //acr root


      var item = Sitecore.Context.Item;

      while (item != null)
      {
        if (item.IsDerived(Constants.Templates._Site.ID))
        {
          itemId = item.ID.ToString();
          break;
        }
        if (item.ID == Constants.Templates.SitecoreContentNodeID)
        {
          break;
        }
        item = item.Parent;
      }

      return _repository.GetContentItem<INavigationRoot>(itemId);
    }

    public INavigationRoot GetNavigationContentByItem(string itemId)
    {
      if(string.IsNullOrEmpty(itemId))
      {
        itemId = "{B3C7CCAA-6EBC-4B88-8371-DA7F3829B587}"; //ideas root
      }
      return _repository.GetContentItem<INavigationRoot>(itemId);
    }
    public IIWNavigationRoot GetIWMainNavigationContent()
    {
      string itemId = "{2278B766-54D5-41EA-B400-F6C27E1948ED}";

      var item = Sitecore.Context.Item;

      while (item != null)
      {
        if (item.IsDerived(Constants.Templates._Site.ID))
        {
          itemId = item.ID.ToString();
          break;
        }
        if (item.ID == Constants.Templates.SitecoreContentNodeID)
        {
          break;
        }
        item = item.Parent;
      }

            return _repository.GetContentItem<IIWNavigationRoot>(itemId);
        }

        public IBreadcrumbs GetIWBreadcrumbsContent(string contentGuid)
        {
            Database database = Sitecore.Context.Database;
            Item currentPage = database.GetItem(contentGuid);

            List<Link> links = new List<Link>();

            while (currentPage != null)
            {
                if (currentPage.TemplateName == "Site Root")
                {
                    break;
                }
                else if (currentPage.IsDerived(Constants.Templates.Navigable.ID) && currentPage.Fields["Short Title"] != null)
                {
                    if(!string.IsNullOrWhiteSpace(currentPage.Fields[Sitecore.FieldIDs.LayoutField].Value))
                    {
                        links.Add(new Link { Url = LinkManager.GetItemUrl(currentPage), Text = currentPage.Fields["Short Title"].ToString() });
                    }                   
                }

                currentPage = currentPage.Parent;
            }

            links.Reverse();

            Breadcrumbs breadcrumbs = new Breadcrumbs
            {
                Id = new ID(contentGuid),
                Links = links
            };

            return breadcrumbs;
        }
        public IIWNavigationRoot GetIdeasMainNavigationContent()
        {
            string itemId = "{A03BD132-09AA-44A2-B8C9-DE77B372D588}";

            var item = Sitecore.Context.Item;

            while (item != null)
            {
                if (item.IsDerived(Constants.Templates._Site.ID))
                {
                    itemId = item.ID.ToString();
                    break;
                }
                if (item.ID == Constants.Templates.SitecoreContentNodeID)
                {
                    break;
                }
                item = item.Parent;
            }

            return _repository.GetContentItem<IIWNavigationRoot>(itemId);
        }
        
    }
}