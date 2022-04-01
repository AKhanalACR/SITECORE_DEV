using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;


namespace ACRHelix.Feature.IdeasContent.Models
{
  [SitecoreType(TemplateId = "{11D1C2E5-A0EA-44B9-992F-E372B0649E92}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasPatientTitle2Column : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("{87DC685D-9564-48E7-BFA4-C4E84A38D347}", SitecoreFieldType.SingleLineText)]
        public virtual string Title { get; set; }

    [SitecoreField("{9642C9BD-CE0A-48DB-ACDC-DC1BCBCF0F47}", SitecoreFieldType.SingleLineText)]
    public virtual string FirstColumnTitle { get; set; }

    [SitecoreField("{BFCADBFA-0D15-4B12-BB40-C08174A68FBF}", SitecoreFieldType.Image)]
        public virtual Image FirstColumnIcon { get; set; }

        [SitecoreField("{E60B9635-92F5-4488-96E0-A166F6C01117}", SitecoreFieldType.RichText)]
        public virtual string FirstColumnText { get; set; }

    [SitecoreField("{426BB366-BACE-4DDB-929E-F0676FFEE5DF}", SitecoreFieldType.SingleLineText)]
    public virtual string SecondColumnTitle { get; set; }

    [SitecoreField("{4710F471-9D58-4225-96E5-015EE2A6A4A7}", SitecoreFieldType.Image)]
    public virtual Image SecondColumnIcon { get; set; }

    [SitecoreField("{DC354420-362B-4420-BA30-7E065F0D1118}", SitecoreFieldType.RichText)]
    public virtual string SecondColumnText { get; set; }



  }
}