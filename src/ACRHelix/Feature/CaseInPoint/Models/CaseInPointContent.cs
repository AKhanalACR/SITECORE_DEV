using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CaseInPoint.Models
{
  public class CaseInPointContent : MiniCaseInPointContent
  {  
    [SitecoreField(FieldId = "{609204FE-1D55-4171-AD1F-4F870EAD7CCE}")]
    public virtual string IntroText { get; set; }

    [SitecoreField(FieldId = "{7F43D900-27A7-4116-B2F6-3D93E35BAE74}")]
    public virtual string HeaderLink { get; set; }
  }
}