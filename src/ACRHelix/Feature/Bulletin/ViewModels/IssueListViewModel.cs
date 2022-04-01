using ACRHelix.Feature.Bulletin.Models;
using System.Collections.Generic;

namespace ACRHelix.Feature.Bulletin.ViewModels
{
  public class IssueListViewModel
  {
    public List<int> Years { get; set; } = new List<int>();

    public IssueListPage IssueListPage { get; set; }
  }
}