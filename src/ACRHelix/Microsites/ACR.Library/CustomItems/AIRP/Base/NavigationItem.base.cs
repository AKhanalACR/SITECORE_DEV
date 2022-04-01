using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.AIRP.Base
{
public partial class NavigationItem : CustomItem
{

public static readonly string TemplateId = "{F295E52D-A2CF-452C-B08F-A20B307FC9C8}";


#region Boilerplate CustomItem Code

public NavigationItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator NavigationItem(Item innerItem)
{
	return innerItem != null ? new NavigationItem(innerItem) : null;
}

public static implicit operator Item(NavigationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField IncludeinNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Include in Navigation"]);
	}
}


public CustomTextField NavigationTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation Title"]);
	}
}


#endregion //Field Instance Methods
}
}