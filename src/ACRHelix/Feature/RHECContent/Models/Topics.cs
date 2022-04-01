using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
  public class Topics : ITopics
  {
    public ID Id { get; set; }
    public string Name { get; set; }
    public string TopicName { get; set; }

  }
}