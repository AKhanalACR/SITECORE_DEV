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
  [SitecoreType(TemplateId = "{475B6B38-78C8-4CDC-9BC0-1BAE215E06F6}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class RichTextButton : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{5D67C058-A511-45B3-95C2-B1E744D1DDA9}", SitecoreFieldType.SingleLineText)]
    public virtual string Title { get; set; }
    [SitecoreField("{B5B23B26-613F-4990-BD73-7CB1F70EC989}", SitecoreFieldType.SingleLineText)]
    public virtual string SubTitle { get; set; }
    [SitecoreField("{D404BAEE-3D3F-47C7-B91B-FB85BD89EBA4}", SitecoreFieldType.RichText)]
    public virtual string RichText { get; set; }
    [SitecoreField("{AC08996A-D113-41DB-AA07-27CB7A326062}", SitecoreFieldType.Multilist)]
    public virtual IEnumerable<Models.Button>  Button { get; set; }


  }
}