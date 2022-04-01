using ACR.Foundation.Personify.Models.Products;
using ACRHelix.Feature.MeetingsCalendar.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MeetingsCalendar.Models
{
  [SitecoreType(TemplateId = "{6C0A1097-31B1-4406-8922-D5D4BB9E8925}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class MeetingOrCourseHeader : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual String Title { get; set; }
    public virtual String SubTitle { get; set; }
    [SitecoreField(FieldName = "Header Image")]
    public virtual Image HeaderImage { get; set; }
    public virtual IEnumerable<ProductStubItem> Products { get; set; }
    [SitecoreField(FieldName = "Meeting Type")]
    public virtual string MeetingType { get; set; }
    [SitecoreField(FieldName = "Register Link")]
    public virtual Link RegisterLink { get; set; }
  }
}