using ACRHelix.Feature.ACRDashboard.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ACRDashboard.Models
{
  [SitecoreType(TemplateId = "{27EE47CE-DD24-4572-84C8-94FBBC2E3EF8}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ACRDashboard : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField(FieldId = "{73620E47-1AA2-4C8A-88A4-FEA074B46F23}")]
    public virtual Link GatewayLink { get; set; }

    [SitecoreField(FieldId = "{D78FF415-AEF7-4A12-98F3-6802438F91BA}")]
    public virtual string CMEText { get; set; }

    [SitecoreField(FieldId = "{32734183-E4A6-4484-91E8-C792988F4F95}", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Treelist)]
    public virtual IEnumerable<DashboardNavigationItem> SideNavigationItems { get; set; }

    [SitecoreField(FieldId = "{507122EC-CF83-4C08-8497-B26F865026BF}", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Treelist)]
    public virtual IEnumerable<DashboardNavigationItem> EngageLinks { get; set; }

    [SitecoreField(FieldId = "{AE30404A-3DAA-41B6-8003-4D1F1A0DC8D0}")]
    public virtual Link MembershipInformation { get; set; }

    [SitecoreField(FieldId = "{40B9FA21-F8DC-44BB-A059-2CB37A315D1B}")]
    public virtual Link SelectMyNewsLink {get;set;}

    [SitecoreField(FieldId = "{B6B1E728-FD26-4878-9746-B324E33DF0B5}")]
    public virtual string CMETitle { get; set; }

    [SitecoreField(FieldId = "{0C2F77F4-18E5-45C0-B9C4-76F13D4139D4}")]
    public virtual Link MyMessages { get; set; }

  }
}