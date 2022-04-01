using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore;
using Sitecore.Data;

namespace ACRHelix.Feature.Chapters.Models
{
  [SitecoreType(TemplateId = "{54FC426B-53E5-4285-B8A6-07725D00B429}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ChapterMeeting : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Title")]
    public virtual string MeetingTitle { get; set; }

    [SitecoreField("Start Date")]
    public virtual DateTime StartDate { get; set; }

    [SitecoreField("End Date")]
    public virtual DateTime EndDate { get; set; }

    public virtual string Url { get; set; }

    public virtual string Location { get; set; }

    [SitecoreField("Additional Information")]
    public virtual string AdditionalInformation {get;set;}

    public bool TimeSet { get; set; } = false;


    public virtual DateTime FilterDate
    {
      get
      {
        if (EndDate != DateTime.MinValue)
        {
          return EndDate;
        }
        return StartDate;
      }
    }



   

  
  }
}