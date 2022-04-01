using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.DSIHomeBanner.Models
{
  [SitecoreType(TemplateId = "{76A3EDF1-BD7E-478C-A402-AE15330F16C5}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class DSIHomeBanner : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{0C06537E-65ED-423A-9999-4435D93112D5}", SitecoreFieldType.SingleLineText)]
    public virtual string MainTitle { get; set; }

    [SitecoreField("{B3521882-1744-4793-884E-1B9D978164F1}", SitecoreFieldType.SingleLineText)]
    public virtual string SmallTitle { get; set; }

    [SitecoreField("{787B15E5-F856-47DC-B1CE-5A4DF9FB2BEE}", SitecoreFieldType.SingleLineText)]
    public virtual string LeftTitle { get; set; }

    [SitecoreField("{00559C96-3427-4C0E-848E-F749FDC3D320}", SitecoreFieldType.GeneralLink)]
    public virtual Link LeftLink { get; set; }

    [SitecoreField("{53E1F75E-C691-415F-8278-35D022B1301D}", SitecoreFieldType.SingleLineText)]
    public virtual string CenterTitle { get; set; }

    [SitecoreField("{39398FD2-E00C-44DF-A328-C8FA6E198F1B}", SitecoreFieldType.GeneralLink)]
    public virtual Link CenterLink { get; set; }

    [SitecoreField("{73A9D2BD-C8C5-4AD2-9324-E26A62E63DE3}", SitecoreFieldType.SingleLineText)]
    public virtual string RightTitle { get; set; }

    [SitecoreField("{8382ADC4-EBA9-488B-BB48-56A6E65B9F23}", SitecoreFieldType.GeneralLink)]
    public virtual Link RightLink { get; set; }
  }
}