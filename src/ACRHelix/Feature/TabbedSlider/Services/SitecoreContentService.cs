using ACRHelix.Feature.TabbedSlider.Models;
using ACRHelix.Foundation.Repository.Content;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using ACRHelix.Feature.TabbedSlider.Constants;

namespace ACRHelix.Feature.TabbedSlider.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public ITabbedSlider GetTabbedSliderContent(string contentGuid)
    {
      return _repository.GetContentItem<ITabbedSlider>(contentGuid);
    }

    public IEnumerable<ISlide> GetPopularTabSliderContent(Guid Id)
    {
      List<ISlide> slides = new List<ISlide>();

      ID popId = new ID();

      int daysPopular = 30;

      if (ID.TryParse(Id, out popId))
      {
        var tabItem = Sitecore.Context.Database.GetItem(popId);
        if (tabItem != null)
        {
          var field = tabItem.Fields["Days"];
          if (field != null) {
            string days = field.Value;
            if (!int.TryParse(days, out daysPopular))
            {
              daysPopular = 30;
            }
          }

          MultilistField treeList = tabItem.Fields["Forced Pages"];
          if (treeList != null)
          {
            foreach (var id in treeList.TargetIDs)
            {
              var item = Sitecore.Context.Database.GetItem(id);
              if (item != null)
              {
                if (item.IsDerived(SlideFields.BasePageTemplateID))
                {

                  ImageField image = item.Fields[SlideFields.ImageFieldID];


                  var tileText = item.Fields[SlideFields.TileTextFieldID].Value;
                  if (string.IsNullOrWhiteSpace(tileText))
                  {
                    tileText = item.Fields[SlideFields.MetaDescriptionFieldID].Value;
                  }
                  slides.Add(new Slide
                  {
                    Id = item.ID.ToGuid(),
                    //Image = gmImage,
                    //Link = new Link { Url = Sitecore.Links.LinkManager.GetItemUrl(page) },
                    LinkUrl = Sitecore.Links.LinkManager.GetItemUrl(item),
                    ImageUrl = Sitecore.Links.LinkManager.GetItemUrl(image.MediaItem),
                    Text = tileText,
                    Title = item.Fields[SlideFields.TitleFieldID].Value
                  });
                }
              }
            }
          }
        }
      }



      var popularPages = GetMostPopular(100, daysPopular);

      foreach (var page in popularPages)
      {
        //if derived from page base template
        if (page.IsDerived(SlideFields.BasePageTemplateID))
        {
          string PageLinkUrl = Sitecore.Links.LinkManager.GetItemUrl(page);
          if (!PageLinkUrl.Contains("/sitecore/content/"))
          {            
              ImageField image = page.Fields[SlideFields.ImageFieldID];
              var tileText = page.Fields[SlideFields.TileTextFieldID].Value;
              if (string.IsNullOrWhiteSpace(tileText))
              {
                tileText = page.Fields[SlideFields.MetaDescriptionFieldID].Value;
              }
              slides.Add(new Slide
              {
                Id = page.ID.ToGuid(),
                //Image = gmImage,
                //Link = new Link { Url = Sitecore.Links.LinkManager.GetItemUrl(page) },
                LinkUrl = Sitecore.Links.LinkManager.GetItemUrl(page),
                ImageUrl = Sitecore.Links.LinkManager.GetItemUrl(image.MediaItem),
                Text = tileText,
                Title = page.Fields[SlideFields.TitleFieldID].Value
              });
            }          
        }
      }

      //get most popular pages with tile images from analytics
      //convert pages to slides


      return slides.Take(9);
    }

    public static List<Item> GetMostPopular(int count, int daysToInclude)
    {
      var sqlServerDataApi = new SqlServerDataApi(Sitecore.Configuration.Settings.GetConnectionString("reporting"));

      // Base Query
      var query = @"SELECT TOP " + count.ToString() + @"
		                        A.ItemId,
		                        A.DailyCount
                        FROM
                        (
                        SELECT	ItemId, 
                                SUM([Visits]) AS DailyCount
                        FROM    Fact_PageViews
                        WHERE   Date >= DATEADD(DAY, -" + daysToInclude.ToString() + @", GETDATE()) ";

      // Group And Sort
      query += @"GROUP BY ItemId
                        ) AS A
                        ORDER BY A.DailyCount DESC";


      var result = new List<Item>();

      var reader = sqlServerDataApi.CreateReader(query);
      while (reader.Read())
      {
        var itemID = reader.InnerReader.GetGuid(0);
        var scItem = Sitecore.Context.Database.GetItem(new ID(itemID));
        if (scItem != null)
        {
          //exlude login pagenot found error
          if (scItem.ID != new ID("{658E9C4C-194C-44C7-A9E5-EC30D7292235}") && scItem.ID != new ID("{464B2C60-1D19-4D85-9EF9-281B36CF008F}") && scItem.ID != new ID("{2C75888A-96E6-40AB-826D-15892D2F0039}"))
          {
            ImageField imageField = scItem.Fields[SlideFields.ImageFieldID];
            if (imageField != null)
            {
              if (imageField.MediaItem != null)
              {
                if (imageField.MediaID != new ID("{28677550-0E49-472A-BE69-42F8C7180D0F}"))
                {
                  var image = new MediaItem(imageField.MediaItem);
                  //if item has tile image
                  if (image != null)
                  {
                    result.Add(scItem);
                  }
                }
              }
            }
          }
        }
      }
      return result;
    }
  }
}