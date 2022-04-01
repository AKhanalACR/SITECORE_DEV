using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch.Pipelines.GetDependencies;
using Sitecore.ContentSearch;
using ACR.Foundation.Personify.Models.Products;
using ACR.Foundation.Personify.MeetingSearch;

namespace ACRHelix.Foundation.CustomCoveo.Processors
{
  public class GetItemIndexDependencies : Sitecore.ContentSearch.Pipelines.GetDependencies.BaseProcessor
  {
    public override void Process(GetDependenciesArgs args)
    {
      var scIndexable = args.IndexedItem as SitecoreIndexableItem;
      if (scIndexable != null)
      {
        if (scIndexable.Item != null)
        {
          if (!string.Equals(scIndexable.Item.Database.Name, "web", StringComparison.OrdinalIgnoreCase))
          {
            return;
          };
          var tid = scIndexable.Item.TemplateID.ToString();
          if (tid == ProductStubItem.TemplateID)
          {
            MeetingSearchManager msm = new MeetingSearchManager(MeetingSearchManager.IndexEnum.Web);
            var meetings = msm.GetMeetings(scIndexable.Item.ID);

            foreach (var m in meetings)
            {
              var mm = m.GetItem();
              if (mm != null)
              {
                var iid = (SitecoreItemUniqueId)mm.Uri;
                if (!args.Dependencies.Contains(iid))
                {
                  args.Dependencies.Add(iid);
                }
              }
            }

          }


          if (tid == SitecoreConstants.Templates.MeetingOrCourse.TemplateID)
          {

            var productField = scIndexable.Item.Fields[SitecoreConstants.Templates.MeetingOrCourse.Fields.Products];
            if (productField != null)
            {
              string[] ids = productField.Value.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
              foreach (string id in ids)
              {
                var item = scIndexable.Item.Database.GetItem(id);
                if (item != null)
                {
                  var iid = (SitecoreItemUniqueId)item.Uri;
                  if (!args.Dependencies.Contains(iid))
                  {
                    args.Dependencies.Add(iid);
                  }
                }

              }
            }
          }

          if (tid == SitecoreConstants.Templates.NewsItem.TemplateID)
          {
            if (scIndexable.Item.Parent.TemplateID.ToString() == SitecoreConstants.Templates.NewsIssue.TemplateID)
            {
              args.Dependencies.Add((SitecoreItemUniqueId)scIndexable.Item.Parent.Uri);
            }
          }
        }
      }
    }
  }
}