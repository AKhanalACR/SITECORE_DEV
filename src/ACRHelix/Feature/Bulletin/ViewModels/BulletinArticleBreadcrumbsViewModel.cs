using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.ViewModels
{
  public class BulletinArticleBreadcrumbsViewModel
  {
    public ID Id { get; set; }
    public List<Link> Links { get; set; }
  }
}