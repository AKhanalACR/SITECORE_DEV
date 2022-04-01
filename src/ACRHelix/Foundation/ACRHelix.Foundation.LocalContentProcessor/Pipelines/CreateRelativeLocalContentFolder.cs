using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.SecurityModel;

namespace ACRHelix.Foundation.LocalContentProcessor
{
  public class CreateRelativeLocalContentFolder
  {
    private static ID DataSourceLocationField = new ID("{B5B27AF1-25EF-405C-87CE-369B3A004016}");

    private static ID LocalContentTemplateID = new ID("{08C1C3FE-99F2-40E8-B4CF-535724D4F1AF}");
    private static ID ChapterMeetingFolderTemplateID = new ID("{0B9EF086-0648-49B6-896F-F82D9A79673C}");
    private static ID ChapterNewsFolderTemplateID = new ID("{2393BB04-21F8-449F-8F70-E90D1D030823}");

    private static ID ChapterTemplateID = new ID("{185E7629-5035-4764-8439-ABC39402C4DC}");

    public void Process(GetRenderingDatasourceArgs args)
    {
      string dataSourceLocation = args.RenderingItem.Fields[DataSourceLocationField].Value;

      bool validLocation = false;
      if (!string.IsNullOrWhiteSpace(dataSourceLocation))
      {
        if (dataSourceLocation.StartsWith("./Local Content") ||
          dataSourceLocation.StartsWith("./Meetings") ||
          dataSourceLocation.StartsWith("./Chapter News"))
        {
          validLocation = true;
        }
      }
      if (!validLocation || string.IsNullOrWhiteSpace(args.ContextItemPath))
      {
        return;
      }

      string subFolderPath = args.ContextItemPath + dataSourceLocation.Substring(1);
      if (args.ContentDatabase.GetItem(subFolderPath) != null)
      {
        return;
      }

      Item currentItem = args.ContentDatabase.GetItem(args.ContextItemPath);
      if (currentItem != null)
      {
        string newItemName = dataSourceLocation.Substring(2);
        ID createTemplateID = LocalContentTemplateID;


        if (currentItem.TemplateID == ChapterTemplateID && dataSourceLocation.StartsWith("./Meetings"))
        {
          createTemplateID = ChapterMeetingFolderTemplateID;
        }
        if (currentItem.TemplateID == ChapterTemplateID && dataSourceLocation.StartsWith("./Chapter News"))
        {
          createTemplateID = ChapterNewsFolderTemplateID;
        }

        using (new SecurityDisabler())
        {
          Client.Site.Notifications.Disabled = true;
          currentItem.Add(newItemName, new TemplateID(createTemplateID));
          Client.Site.Notifications.Disabled = false;
        }
      }

    }
  }
}