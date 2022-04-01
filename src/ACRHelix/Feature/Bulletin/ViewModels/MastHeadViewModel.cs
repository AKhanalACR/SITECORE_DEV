using ACRHelix.Feature.Bulletin.Models;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.ViewModels
{
  public class MastHeadViewModel
  {
    public List<TopicPage> Topics { get; set; }

    public Topic CurrentTopic { get; set; }

    public string BulletinHomePageUrl { get; set; }
  }
}