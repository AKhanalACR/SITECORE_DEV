using ACRHelix.Foundation.Tags.Models;
using Sitecore.ContentSearch;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.Tags.Content
{
  public class TagItemRepository
  {
    private ISearchIndex acrTagIndex;

    public ISearchIndex AcrTagIndex
    {
      get
      {
        return acrTagIndex;
      }
    }

    public TagItemRepository()
    {
      acrTagIndex = ContentSearchManager.GetIndex("acr-tag-index");
    }

    public ACRTagSearchResult GetACRTagItem(ID id)
    {
      ACRTagSearchResult item = null;

      using (var context = acrTagIndex.CreateSearchContext())
      {
        item = context.GetQueryable<ACRTagSearchResult>().FirstOrDefault(x => x.ItemId == id);
      }
      return item;
    }

    public List<ACRTagSearchResult> GetTagItemsByInterest(string[] interestTagIDs)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        foreach (var tag in interestTagIDs)
        {
          var r = context.GetQueryable<ACRTagSearchResult>().Where(x => x.PersonifyInterests.Contains(tag)).ToList();
          if (r.Count > 0)
          {
            results.AddRange(r);
          }
        }
      }
      return results;
    }

    public List<ACRTagSearchResult> GetTagItemsByInterest(string interestTagID)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        results = context.GetQueryable<ACRTagSearchResult>().Where(x => x.PersonifyInterests.Contains(interestTagID)).ToList();
      }
      return results;
    }

    public List<ACRTagSearchResult> GetTagItemsByContent(string contentTagID)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        results = context.GetQueryable<ACRTagSearchResult>().Where(x => x.ContentTags.Contains(contentTagID)).ToList();
      }
      return results;
    }

    public List<ACRTagSearchResult> GetTagItemsByContent(string[] contentTagID)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        foreach (var tag in contentTagID)
        {
          var r = context.GetQueryable<ACRTagSearchResult>().Where(x => x.ContentTags.Contains(tag)).ToList();
          if (r.Count > 0)
          {
            results.AddRange(r);
          }
        }
      }
      return results;
    }

    public List<ACRTagSearchResult> GetTagItemsBySubSpecialty(string[] subSpecTagID)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        foreach (var tag in subSpecTagID)
        {
          var r = context.GetQueryable<ACRTagSearchResult>().Where(x => x.PersonifySubspecialties.Contains(tag)).ToList();
          if (r.Count > 0)
          {
            results.AddRange(r);
          }
        }
      }
      return results;
    }

    public List<ACRTagSearchResult> GetTagItemsBySubSpecialty(string subSpecTagID)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        results = context.GetQueryable<ACRTagSearchResult>().Where(x => x.PersonifySubspecialties.Contains(subSpecTagID)).ToList();
      }
      return results;
    }

    public List<ACRTagSearchResult> GetTagItemsByModality(string modalityTagID)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        results = context.GetQueryable<ACRTagSearchResult>().Where(x => x.PersonifyModalities.Contains(modalityTagID)).ToList();
      }
      return results;
    }

    public List<ACRTagSearchResult> GetTagItemsByModality(string[] modalityTagID)
    {
      List<ACRTagSearchResult> results = new List<ACRTagSearchResult>();

      using (var context = acrTagIndex.CreateSearchContext())
      {
        foreach (var tag in modalityTagID)
        {
          var r = context.GetQueryable<ACRTagSearchResult>().Where(x => x.PersonifyModalities.Contains(tag)).ToList();
          if (r.Count > 0)
          {
            results.AddRange(r);
          }
        }
      }
      return results;
    }

  }
}