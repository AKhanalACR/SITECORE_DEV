using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class OrganizationsItem : CustomItem
{
public static readonly string TemplateId = "{5C30060E-EA3D-4945-BDE6-9042DF018372}";

#region Boilerplate CustomItem Code

public OrganizationsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator OrganizationsItem(Item innerItem)
{
	return innerItem != null ? new OrganizationsItem(innerItem) : null;
}

public static implicit operator Item(OrganizationsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField MemberTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Member Title"]);
	}
}


public CustomTextField MemberDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Member Description"]);
	}
}


#endregion //Field Instance Methods
}
}