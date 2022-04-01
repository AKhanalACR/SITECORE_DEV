using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ACRHelix.Feature.Bulletin.Indexing
{
  public class ComputedIssuePDFIndexField : AbstractComputedIndexField
  {
    public override object ComputeFieldValue(IIndexable indexable)
    {
      // item is currently being indexed.
      Item item = indexable as SitecoreIndexableItem;
      // null check on item
      if (item != null)
      {
        FileField img = item.Fields["{126EA420-4F0B-470B-A85B-8DE7A7A81640}"];

        string imgUrl = img == null || img.MediaItem == null ? null : LinkManager.GetItemUrl(img.MediaItem);

        if (imgUrl != null)
        {
          int mediaIndex = imgUrl.IndexOf("/-/media");
          if (mediaIndex > 0)
          {
            imgUrl = imgUrl.Substring(mediaIndex);
          }
          return imgUrl;
        }
      }
      return null;
    }
  }
}