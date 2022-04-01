using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class ParticipatingOrganizationItem : CustomItem
{
public static readonly string TemplateId = "{899F6957-1473-4F64-91D2-37CC8A935AE2}";
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