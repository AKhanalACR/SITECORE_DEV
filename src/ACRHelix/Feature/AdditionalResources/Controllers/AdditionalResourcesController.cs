using ACRHelix.Feature.AdditionalResources.Models;
using ACRHelix.Feature.AdditionalResources.Services;
using ACRHelix.Feature.AdditionalResources.ViewModels;
using ACRHelix.Foundation.Index.Models;
using ACRHelix.Foundation.Dictionary.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACRHelix.Foundation.Tags.Content;
using Glass.Mapper.Sc;

namespace ACRHelix.Feature.AdditionalResources
{
  public class AdditionalResourcesController : Controller
  {
    private readonly IContentService _contentService;
    private TagItemRepository _tagItemRepository;

    public AdditionalResourcesController(IContentService contentService)
    {
      _contentService = contentService;
      _tagItemRepository = new TagItemRepository();
    }

    public ViewResult AdditionalResources()
    {
      var viewModel = new AdditionalResourcesViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      if (!String.IsNullOrEmpty(dataSource))
      {
        int displayCount = 4;
        var AdditionalResourcesContent = _contentService.GetAdditionalResourcesContent(dataSource);
        if (AdditionalResourcesContent != null)
        {
          viewModel.Id = AdditionalResourcesContent.Id;
          viewModel.Title = AdditionalResourcesContent.Title;
          viewModel.SubTitle = AdditionalResourcesContent.SubTitle;
          displayCount = AdditionalResourcesContent.DisplayCount;
          viewModel.Resources = AdditionalResourcesContent.Resources.Take(displayCount);
        }
        if (viewModel.Resources != null && viewModel.Resources.Count() < displayCount)
        {
          viewModel.Resources = AddResourcesByTag(viewModel.Resources, displayCount);
        }
      }
      return View(viewModel);
    }

    private IEnumerable<AdditionalResourcesItem> AddResourcesByTag(IEnumerable<AdditionalResourcesItem> resources, int displayCount)
    {
      string[] excludedTemplates = new string[] { "Chapter News", "Case Study", "NewsArticle", "Press Release","Product Stub" };
      var tagResources = resources.ToList();
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

          foreach (var im in interestMatches)
          {
            if (im.ItemId != currentItemId && !excludedTemplates.Contains(im.TemplateName))
            {
              var addItem = service.Cast<AdditionalResourcesItem>(im.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  tagResources.Add(addItem);

                  if (tagResources.Count >= displayCount)
                  {
                    return tagResources;
                  }
                }
              }
            }
          }
        }
        //next check subspecs for matches
        if (!string.IsNullOrWhiteSpace(currentItemTags.PersonifySubspecialties))
        {
          string[] subspecs = currentItemTags.PersonifySubspecialties.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          var matches = _tagItemRepository.GetTagItemsBySubSpecialty(subspecs);

          foreach (var m in matches)
          {
            if (m.ItemId != currentItemId && !excludedTemplates.Contains(m.TemplateName))
            {
              var addItem = service.Cast<AdditionalResourcesItem>(m.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  tagResources.Add(addItem);
                  if (tagResources.Count >= displayCount)
                  {
                    return tagResources;
                  }
                }
              }
            }
          }
        }
        //next check tagcontent for matches
        if (!string.IsNullOrWhiteSpace(currentItemTags.ContentTags))
        {
          string[] tags = currentItemTags.ContentTags.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          var matches = _tagItemRepository.GetTagItemsByContent(tags);

          foreach (var m in matches)
          {
            if (m.ItemId != currentItemId && !excludedTemplates.Contains(m.TemplateName))
            {
              var addItem = service.Cast<AdditionalResourcesItem>(m.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  tagResources.Add(addItem);

                  if (tagResources.Count >= displayCount)
                  {
                    return tagResources;
                  }
                }
              }
            }
          }
        }

        //finally check modalities for matches
        if (!string.IsNullOrWhiteSpace(currentItemTags.PersonifyModalities))
        {
          string[] tags = currentItemTags.PersonifyModalities.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
          var matches = _tagItemRepository.GetTagItemsByModality(tags);

          foreach (var m in matches)
          {
            if (m.ItemId != currentItemId && !excludedTemplates.Contains(m.TemplateName))
            {
              var addItem = service.Cast<AdditionalResourcesItem>(m.GetItem());
              if (addItem != null)
              {
                if (tagResources.FirstOrDefault(x => x.Id == addItem.Id) == null)
                {
                  tagResources.Add(addItem);

                  if (tagResources.Count >= displayCount)
                  {
                    return tagResources;
                  }
                }
              }
            }
          }
        }
      }

      return tagResources;
    }
  }
}