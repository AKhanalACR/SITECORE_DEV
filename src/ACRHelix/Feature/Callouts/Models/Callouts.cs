using System.Collections.Generic;
using Sitecore.Data;

namespace ACRHelix.Feature.Callouts.Models
{
  public class Callouts : ICallouts
  {
    public ID Id { get; set; }

    public string Title { get; set; }

    public IEnumerable<ICalloutsItem> CalloutItems { get; set; }

    public IEnumerable<ChapterLocatorCallout> ChaperLocator { get; set; }
  }
}