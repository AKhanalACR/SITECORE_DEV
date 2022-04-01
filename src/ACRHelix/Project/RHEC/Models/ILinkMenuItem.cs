using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace RHEC.Website.Models
{
  public interface ILinkMenuItem
  {
    ID Id { get; set; }
    string Title { get; set; }
    Link Link { get; set; }
  }
}