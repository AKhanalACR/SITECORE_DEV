using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.ViewModels
{
  public class TagsViewModel
  {
    public List<BulletinTag> BulletinTags { get; set; } = new List<BulletinTag>();
  }

  public class BulletinTag
  {
    public string TagDisplayName { get; set; }

    public string TagName { get; set; }

    public string TagLink { get; set; }
  }
}