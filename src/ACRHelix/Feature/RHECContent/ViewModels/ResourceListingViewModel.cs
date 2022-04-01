using ACRHelix.Feature.RhecContent.Models;
using Sitecore.Data;
using System.Collections.Generic;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
  public class ResourceListingViewModel
  {
    public ID id { get; set; }
    public string SubTitle { get; set; }

    public string Title { get; set; }
    public int CurrentPage { get; set; }

    public int SummaryLength { get; set; }

    public int TotalRows { get; set; }

    public int MaxPages { get; set; }

    public bool PageResult { get; set; }
    public bool DisplayTopics { get; set; }
    public string NoResourcetext { get; set; }
    public string PaginationString { get; set; }
    public IEnumerable<ResourcesSearchResult> Resources { get; set; }
    public IEnumerable<TopicViewModel> Topics { get; set; }
    public string AllButtonString { get; set; }
    public bool ShowAllTopics { get; set; }
    public int settingTopicsCount { get; set; }
  }
}