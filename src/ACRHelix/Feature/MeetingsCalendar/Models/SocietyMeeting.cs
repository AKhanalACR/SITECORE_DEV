using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore;
using Sitecore.Data;

namespace ACRHelix.Feature.MeetingsCalendar.Models{

  [SitecoreType(TemplateId = "{DE275A98-20B2-43B6-A3B3-9A159837057F}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class SocietyMeeting : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Title")]
    public virtual string MeetingTitle { get; set; }

    [SitecoreField("Society Name")]
    public virtual string SocietyName { get; set; }

    [SitecoreField("Start Date")]
    public virtual DateTime StartDate { get; set; }

    [SitecoreField("End Date")]
    public virtual DateTime EndDate { get; set; }

    public virtual string Url { get; set; }

    public virtual string Location { get; set; }

    [SitecoreField("Additional Information")]
    public virtual string AdditionalInformation { get; set; }

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