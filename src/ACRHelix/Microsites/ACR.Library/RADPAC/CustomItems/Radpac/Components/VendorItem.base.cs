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
public partial class VendorItem : CustomItem
{
    public static readonly string TemplateId = "{D53FC554-C2D3-47FA-8E68-2682AC2BBC7B}";
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