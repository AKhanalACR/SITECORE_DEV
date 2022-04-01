using ACRHelix.Feature.RelatedArticles.Services;
using ACRHelix.Feature.RelatedArticles.ViewModels;
using ACRHelix.Foundation.Index.Models;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ACRHelix.Feature.RelatedArticles.Models;
using ACRHelix.Foundation.Tags.Content;
using Glass.Mapper.Sc;

namespace ACRHelix.Feature.RelatedArticles
{
  public class RelatedArticlesController : Controller
  {
    private readonly IContentService _contentService;
    private TagItemRepository _tagItemRepository;

    public RelatedArticlesController(IContentService contentService)
    {
      _contentService = contentService;
      _tagItemRepository = new TagItemRepository();
    }

    public ViewResult RelatedArticles()
    {
      var viewModel = new RelatedArticlesViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        var RelatedArticlesContent = _contentService.GetRelatedArticlesContent(dataSource);
        if (RelatedArticlesContent != null)
        {
          viewModel.Id = RelatedArticlesContent.Id;
        }
        viewModel.Articles = AddResourcesByTag(4);
        //MultilistField tags = Sitecore.Context.Item.Fields["Tags"];
        //if (tags != null)
        //{
        //  IEnumerable<string> tagIds = tags.TargetIDs.Select(t => t.ToShortID().ToString());
        //  //var context = ContentSearchManager.GetIndex("sitecore_master_index").CreateSearchContext();

        //  //var results = _contentService.SearchArticleTags(tagIds, "/sitecore/media library/ACRHelix").ToList();
        //  var results = _contentService.SearchArticleTags(tagIds).ToList();

        //  TagSearchResult self = results.SingleOrDefault(r => r.ItemId == PageContext.Current.Item.ID);
        //  if (self != null) { results.Remove(self); }

        //  viewModel.Articles = results.Select(r => new RelatedArticlesItem { Id = r.ItemId.Guid, Date = r.Date, Title = r.Title, Url = r.Url }).Take(4);
        //}
      }
      return View(viewModel);
    }

    private IEnumerable<RelatedArticlesItem> AddResourcesByTag(int displayCount)
    {      
      string[] includedTemplates = new string[] { "Case Study" , "NewsArticle" , "Press Release", "Coding Source" };
      var tagResources = new List<RelatedArticlesItem>();
      var currentItemId = Sitecore.Context.Item.ID;
      var currentItemTags = _tagItemRepository.GetACRTagItem(Sitecore.Context.Item.ID);
      if (currentItemTags != null)
      {
        SitecoreService service = new SitecoreService(Sitecore.Context.Database);
        //first check interests for matches
        if (!string.IsNullOrWhiteSpace(currentItemTags.PersonifyInterests))
        {
          string[] interests = currentItemTags.PersonifyInterests.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          var interestMatches = _tagItemRepository.GetTagItemsByInterest(interests);
          var articleCache1 = new List<RelatedArticlesItem>();
          foreach (var im in interestMatches)
          {
            if (im.ItemId != currentItemId && includedTemplates.Contains(im.TemplateName))
            {
              var addItem = service.Cast<RelatedArticlesItem>(im.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  articleCache1.Add(addItem);
            
                  //tagResources.Add(addItem);
                  //if (tagResources.Count >= displayCount)
                  //{
                  //   return tagResources.OrderByDescending(d => d.Date);
                  //}
                }
              }
            }
          }

          if(articleCache1.Count > 0)
          {
              articleCache1 = articleCache1.Select(x => new RelatedArticlesItem { Id = x.Id, Title = x.Title, Date = x.Date, Url = x.Url }).Distinct().ToList();
              articleCache1 = articleCache1.OrderByDescending(d => d.Date).ToList();
              foreach (var itm in articleCache1)
              {
                  tagResources.Add(itm);
                  if (tagResources.Count >= displayCount)
                  {
                      return tagResources;
                  }
              }
          }
        }
        //next check subspecs for matches
        if (!string.IsNullOrWhiteSpace(currentItemTags.PersonifySubspecialties))
        {
          string[] subspecs = currentItemTags.PersonifySubspecialties.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          var matches = _tagItemRepository.GetTagItemsBySubSpecialty(subspecs);
          var articleCache2 = new List<RelatedArticlesItem>();
          foreach (var m in matches)
          {
            if (m.ItemId != currentItemId && includedTemplates.Contains(m.TemplateName))
            {
              var addItem = service.Cast<RelatedArticlesItem>(m.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  articleCache2.Add(addItem);

                  //tagResources.Add(addItem);
                  //if (tagResources.Count >= displayCount)
                  //{
                  //  return tagResources.OrderByDescending(d => d.Date);
                  //}
                }
              }
            }
          }
          if (articleCache2.Count > 0)
          {
              articleCache2 = articleCache2.Select(x => new RelatedArticlesItem { Id = x.Id, Title = x.Title, Date = x.Date, Url = x.Url }).Distinct().ToList();
              articleCache2 = articleCache2.OrderByDescending(d => d.Date).ToList();
              foreach (var itm in articleCache2)
              {
                  tagResources.Add(itm);
                  if (tagResources.Count >= displayCount)
                  {
                      return tagResources;
                  }
              }
          }
        }
        //next check tagcontent for matches
        if (!string.IsNullOrWhiteSpace(currentItemTags.ContentTags))
        {
          string[] tags = currentItemTags.ContentTags.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          var matches = _tagItemRepository.GetTagItemsByContent(tags);
          var articleCache3 = new List<RelatedArticlesItem>();
          foreach (var m in matches)
          {
            if (m.ItemId != currentItemId && includedTemplates.Contains(m.TemplateName))
            {
              var addItem = service.Cast<RelatedArticlesItem>(m.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  articleCache3.Add(addItem);

                  //tagResources.Add(addItem);
                  //if (tagResources.Count >= displayCount)
                  //{
                  //  return tagResources.OrderByDescending(d => d.Date);
                  //}
                }
              }
            }
          }

          if (articleCache3.Count > 0)
          {
              articleCache3 = articleCache3.Select(x => new RelatedArticlesItem { Id = x.Id, Title = x.Title, Date = x.Date, Url = x.Url }).Distinct().ToList();
              articleCache3 = articleCache3.OrderByDescending(d => d.Date).ToList();
              foreach (var itm in articleCache3)
              {
                  tagResources.Add(itm);
                  if (tagResources.Count >= displayCount)
                  {
                      return tagResources;
                  }
              }
          }

        }

        //finally check modalities for matches
        if (!string.IsNullOrWhiteSpace(currentItemTags.PersonifyModalities))
        {
          string[] tags = currentItemTags.PersonifyModalities.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          var matches = _tagItemRepository.GetTagItemsByModality(tags);
          var articleCache4 = new List<RelatedArticlesItem>();
          foreach (var m in matches)
          {
            if (m.ItemId != currentItemId && includedTemplates.Contains(m.TemplateName))
            {
              var addItem = service.Cast<RelatedArticlesItem>(m.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  articleCache4.Add(addItem);                  

                  //tagResources.Add(addItem);
                  //if (tagResources.Count >= displayCount)
                  //{
                  //  return tagResources.OrderByDescending(d => d.Date);
                  //}
                }
              }
            }
          }

          if (articleCache4.Count > 0)
          {
              articleCache4 = articleCache4.Select(x => new RelatedArticlesItem { Id = x.Id, Title = x.Title, Date = x.Date, Url = x.Url }).Distinct().ToList();
              articleCache4 = articleCache4.OrderByDescending(d => d.Date).ToList();
              foreach (var itm in articleCache4)
              {
                  tagResources.Add(itm);
                  if (tagResources.Count >= displayCount)
                  {
                      return tagResources;
                  }
              }
          }

        }
      }

      return tagResources;
    }
  }
}