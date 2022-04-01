using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Biography.Models
{
  public interface IBiography : ICMSEntity
  {
    Guid Id { get; set; }
    String Title { get; set; }
    String SubTitle { get; set; }
    String OtherPositions { get; set; }
    //Image Image { get; set; }
    Image BioImage { get; set; }
    String RichText { get; set; }
    String Phone { get; set; }
    String Email { get; set; }

    [SitecoreField(FieldName = "Display Detail Link", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Checkbox)]
    bool DisplayDetailLink { get; set; }

    [SitecoreField(FieldName = "Group Practice Name", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.SingleLineText)]
    String GroupPracticeName { get; set; }

    [SitecoreField(FieldName = "Parent Organization", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.SingleLineText)]
    String ParentOrganization { get; set; }

    [SitecoreInfo(Glass.Mapper.Sc.Configuration.SitecoreInfoType.Url)]
    string URL { get; set; }

  }
}