using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System.Collections.Generic;


namespace ACRHelix.Feature.IdeasContent.Models
{
  [SitecoreType(TemplateId = "{4EC07714-149D-45DB-984E-1C3D7CDA278C}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
    public class IdeasPatientTwoImagesColumn : ICMSEntity
    {
        public virtual ID Id { get; set; }       
    // First Image
    [SitecoreField("{4D6F197D-D738-4756-9E1F-8EA6D3F2A7DE}", SitecoreFieldType.SingleLineText)]
    public virtual string FirstTitle { get; set; }

    [SitecoreField("{70A016DE-E7C6-4490-944E-99ED357E11F6}", SitecoreFieldType.Image)]
        public virtual Image FirstImage { get; set; }

        [SitecoreField("{6589B23D-834A-4D81-BDD1-798A1BEBD655}", SitecoreFieldType.GeneralLink)]
        public virtual Link FirstRedirectionLink { get; set; }

    [SitecoreField("{8EB856F3-58F2-4311-9804-0A5F23988B00}", SitecoreFieldType.SingleLineText)]
    public virtual string FirstContactTitle { get; set; }

    [SitecoreField("{E517F774-2EAF-4684-B444-FA5F5789EF03}", SitecoreFieldType.GeneralLink)]
    public virtual Link FirstContactLink1 { get; set; }

    [SitecoreField("{5A15F75A-1E8D-4E51-95A7-7D6E417206CD}", SitecoreFieldType.Image)]
    public virtual Image FirstContactIcon1 { get; set; }

    [SitecoreField("{A9A5CD6F-42F1-4952-8355-CC115177C580}", SitecoreFieldType.GeneralLink)]
    public virtual Link FirstContactLink2 { get; set; }

    [SitecoreField("{C973DBBE-24E8-4D91-BC30-2F0EAAC3B7A1}", SitecoreFieldType.Image)]
    public virtual Image FirstContactIcon2 { get; set; }

    //Second Image
    [SitecoreField("{AEA79C55-09A3-44C2-8AC9-FB8E1E1B06CD}", SitecoreFieldType.SingleLineText)]
    public virtual string SecondTitle { get; set; }

    [SitecoreField("{551CC116-74CE-410D-8CD0-D18EAF50854D}", SitecoreFieldType.Image)]
    public virtual Image SecondImage { get; set; }

    [SitecoreField("{8A108DBE-4CC4-4903-92BA-BBBCF7E45C8F}", SitecoreFieldType.GeneralLink)]
    public virtual Link SecondRedirectionLink { get; set; }

    [SitecoreField("{C4050EC1-6DAA-47AD-BC78-8EDE49BEDEF3}", SitecoreFieldType.SingleLineText)]
    public virtual string SecondContactTitle { get; set; }

    [SitecoreField("{EC98F71C-BB00-4092-9A1B-2FEC0444E187}", SitecoreFieldType.GeneralLink)]
    public virtual Link SecondContactLink1 { get; set; }

    [SitecoreField("{BD3DC6DC-6EF6-4EDD-81FC-67377A5479FF}", SitecoreFieldType.Image)]
    public virtual Image SecondContactIcon1 { get; set; }

    [SitecoreField("{44EE683A-07B1-4DA9-BBE9-7B8623A42877}", SitecoreFieldType.GeneralLink)]
    public virtual Link SecondContactLink2 { get; set; }

    [SitecoreField("{BAE71850-8687-47D8-8C26-28E3F56DB648}", SitecoreFieldType.Image)]
    public virtual Image SecondContactIcon2 { get; set; }

    // Title
    [SitecoreField("{A4CDB73B-1948-46BF-9EAB-EE6EABC730A4}", SitecoreFieldType.SingleLineText)]
    public virtual string SectionTitle { get; set; }

    [SitecoreField("{B5184D0B-32DF-43F9-85B8-1205E6EAA074}", SitecoreFieldType.Image)]
    public virtual Image TitleBackgroundImage { get; set; }
    [SitecoreField("{44BD8256-53B2-4A17-A7C1-1B423F967D7E}", SitecoreFieldType.Checkbox)]
    public virtual bool ShowTitle { get; set; }
    [SitecoreField("{CE6E87E7-C0D7-483B-B498-3685238256B3}", SitecoreFieldType.Checkbox)]
    public virtual bool ShowContactDetails { get; set; }
  }
}