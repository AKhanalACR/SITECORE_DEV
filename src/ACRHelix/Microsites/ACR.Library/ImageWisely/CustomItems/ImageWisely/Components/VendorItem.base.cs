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
public partial class VendorItem : CustomItem
{
public static readonly string TemplateId = "{A836B93F-5642-406E-82BA-40888B098E2B}";
#region Inherited Base Templates

private readonly OrganizationItem _OrganizationItem;
public OrganizationItem Organization { get { return _OrganizationItem; } }

#endregion

#region Boilerplate CustomItem Code

public VendorItem(Item innerItem) : base(innerItem)
{
	_OrganizationItem = new OrganizationItem(innerItem);

}

public static implicit operator VendorItem(Item innerItem)
{
	return innerItem != null ? new VendorItem(innerItem) : null;
}

public static implicit operator Item(VendorItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}