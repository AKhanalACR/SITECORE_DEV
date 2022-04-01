using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.Radpac.CustomItems.Radpac.Base;

namespace ACR.Library.Radpac.CustomItems.Radpac.Components
{
public partial class ParticipatingOrganizationItem : CustomItem
{
    public static readonly string TemplateId = "{15F8FCA9-1544-408A-A7FC-E5A021F95DC7}";
#region Inherited Base Templates

private readonly OrganizationItem _OrganizationItem;
public OrganizationItem Organization { get { return _OrganizationItem; } }

#endregion

#region Boilerplate CustomItem Code

public ParticipatingOrganizationItem(Item innerItem) : base(innerItem)
{
	_OrganizationItem = new OrganizationItem(innerItem);

}

public static implicit operator ParticipatingOrganizationItem(Item innerItem)
{
	return innerItem != null ? new ParticipatingOrganizationItem(innerItem) : null;
}

public static implicit operator Item(ParticipatingOrganizationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}