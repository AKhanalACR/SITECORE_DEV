using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
  [SitecoreType(TemplateId = "{8292844C-041A-4EEB-B96B-1D1EBE49D934}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Pledge : PageContent
  {
    //public virtual ID Id { get; set; }

    [SitecoreField("{246176E7-D199-45C9-A062-5F8E9D3E2BC6}", SitecoreFieldType.SingleLineText)]
    public virtual string ProTabText { get; set; }

    [SitecoreField("{4D13C303-DD9B-4FBE-BB9B-CC65366C1A5D}", SitecoreFieldType.SingleLineText)]
    public virtual string ProEmailSubject { get; set; }

    [SitecoreField("{7F6C7AFA-9690-4BE1-BE43-5928511F9BA0}", SitecoreFieldType.SingleLineText)]
    public virtual string ProEmailFrom { get; set; }

    [SitecoreField("{D7D3D8BA-0F9D-424B-9B0E-91083D640B54}", SitecoreFieldType.SingleLineText)]
    public virtual string ProEmailTo { get; set; }
    
    [SitecoreField("{FEEEFD13-6DC5-435E-8077-1DCE1FEE670B}", SitecoreFieldType.RichText)]
    public virtual string ProEmailBody { get; set; }

    [SitecoreField("{52238E5B-79D6-44CF-8630-E303EBB30380}", SitecoreFieldType.SingleLineText)]
    public virtual string ProConfirmEmailSubject { get; set; }

    [SitecoreField("{A666E0E9-8DDC-4789-9177-42FAC4DB1B70}", SitecoreFieldType.SingleLineText)]
    public virtual string ProConfirmEmailFrom { get; set; }

    [SitecoreField("{E912B6BC-3272-431D-B765-9E0950DBC7D7}", SitecoreFieldType.RichText)]
    public virtual string ProConfirmEmailBody { get; set; }

    [SitecoreField("{A0F9C430-EEE9-4E7C-AF7B-85CEEEA75440}", SitecoreFieldType.SingleLineText)]
    public virtual string FacTabText { get; set; }

    [SitecoreField("{9EFFA11D-98AA-49AF-AA8F-246F4781C8F6}", SitecoreFieldType.SingleLineText)]
    public virtual string FacEmailSubject { get; set; }

    [SitecoreField("{6AA61D09-AACA-431B-ABE3-761095F504EC}", SitecoreFieldType.SingleLineText)]
    public virtual string FacEmailFrom { get; set; }

    [SitecoreField("{83EAF259-7532-49DA-8C20-DFB4DEF26238}", SitecoreFieldType.SingleLineText)]
    public virtual string FacEmailTo { get; set; }

    [SitecoreField("{1190C275-CA55-4BCC-A4AA-A56D2C501BFE}", SitecoreFieldType.RichText)]
    public virtual string FacEmailBody { get; set; }

    [SitecoreField("{7E0F5F52-A48C-4B22-B31E-6D7285082BE9}", SitecoreFieldType.SingleLineText)]
    public virtual string FacConfirmEmailSubject { get; set; }

    [SitecoreField("{093F34F1-B5E1-4D66-BD10-C91F6B8087B4}", SitecoreFieldType.SingleLineText)]
    public virtual string FacConfirmEmailFrom { get; set; }

    [SitecoreField("{81F2A7A8-0AFB-4572-B78D-0A573C145FBB}", SitecoreFieldType.RichText)]
    public virtual string FacConfirmEmailBody { get; set; }

    [SitecoreField("{2F8DCBA3-2D83-4163-BC2D-18DFCFFD123D}", SitecoreFieldType.SingleLineText)]
    public virtual string ProPledgeTitle { get; set; }
    [SitecoreField("{3D2C765C-8944-476E-9E56-53030E46AB69}", SitecoreFieldType.RichText)]
    public virtual string ProPledgeText { get; set; }
    [SitecoreField("{480D9076-BF2F-41F6-B361-A8B852EFEAC0}", SitecoreFieldType.SingleLineText)]
    public virtual string FacPledgeTitle { get; set; }
    [SitecoreField("{C4AC84AB-B038-423A-941B-EAFA40FB6B08}", SitecoreFieldType.RichText)]
    public virtual string FacPledgeText { get; set; }



  }
}