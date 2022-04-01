using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ACRHelix.Feature.Bulletin.Indexing
{
  public class ComputedImageIndexField : AbstractComputedIndexField
  {
    public override object ComputeFieldValue(IIndexable indexable)
    {
      // item is currently being indexed.
      Item item = indexable as SitecoreIndexableItem;
      // null check on item
      if (item != null)
      {
        ImageField img = item.Fields["{2BF6BD9C-EE0C-4B72-A03E-FD29C32518A6}"];

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