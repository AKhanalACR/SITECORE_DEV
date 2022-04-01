using ACRHelix.Feature.CaseInPoint.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CaseInPoint.Models
{
  public class CaseInPointItem
  {
    public string Title { get; set; }
    public string Text { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }

    public string IntroText { get; set; }

    public CaseInPointContent Content { get; set; }

    public MiniCaseInPointContent MiniContent { get; set; }

    public DateTime Date { get; set; }
  }
}