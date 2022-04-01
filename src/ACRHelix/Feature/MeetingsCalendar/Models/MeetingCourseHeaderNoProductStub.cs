using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;

namespace ACRHelix.Feature.MeetingsCalendar.Models
{
  [SitecoreType(TemplateId = TemplateId, AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class MeetingCourseHeaderNoProductStub : ICMSEntity
  {
    public const string TemplateId = "{63E9A522-4173-4ECC-A0BC-52C0EEA7D241}";

    public virtual ID Id {get;set;}

    public string Title { get; set; }

    public virtual String SubTitle { get; set; }

    [SitecoreField(FieldName = "Header Image")]
    public Image HeaderImage { get; set; }

    [SitecoreField(FieldName = "Meeting Type")]
    public virtual string MeetingType { get; set; }

    [SitecoreField(FieldName = "Register Link")]
    public virtual Link RegisterLink { get; set; }

    [SitecoreField(FieldName = "Meeting Start Date")]
    public virtual DateTime MeetingStartDate { get; set; }

    [SitecoreField(FieldName = "Meeting End Date")]
    public virtual DateTime MeetingEndDate { get; set; }
  }
}