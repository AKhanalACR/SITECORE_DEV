using ACRHelix.Feature.ToolkitContentSection.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACRHelix.Feature.ToolkitContentSection.Models
{
  [SitecoreType(TemplateId = "{61638935-4C4D-4423-A446-3705DF33905B}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ToolkitContentSection : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Section Title")]
    public virtual string SectionTitle { get; set; }

    [SitecoreField("Section Text")]
    public virtual string SectionText { get; set; }

    [SitecoreField("Section Image")]
    public virtual Image SectionImage { get; set; }

    [SitecoreField("Link Image 1")]
    public virtual Image LinkImage1 { get; set; }

    [SitecoreField("Link Image 2")]
    public virtual Image LinkImage2 { get; set; }

    [SitecoreField("Link Image 3")]
    public virtual Image LinkImage3 { get; set; }

    [SitecoreField("Link 1")]
    public virtual Link Link1 { get; set; }

    [SitecoreField("Link 2")]
    public virtual Link Link2 { get; set; }

    [SitecoreField("Link 3")]
    public virtual Link Link3 { get; set; }

    public string ShareID
    {
      get
      {
        return Id.ToShortID().ToString();
      }
    }

    public string DataUrl
    {
      get
      {
        return Sitecore.Context.Item.GetCanonicalUrl() + "?shareID=" + ShareID + "#" + ShareID;
      }
    }
  }
}