using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.Models
{
  public class RichTextSection : IRichTextSection
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool UseDefaultTitleLocation { get; set; }
    public string SubTitle { get; set; }
    public string RichText { get; set; }
    public Image Image { get; set; }

    public bool UseDefaultImageLocation { get; set; }
  }
}