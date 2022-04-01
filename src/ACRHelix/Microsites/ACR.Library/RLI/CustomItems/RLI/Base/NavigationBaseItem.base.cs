using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI.Base
{
public partial class NavigationBaseItem : CustomItem
{

public static readonly string TemplateId = "{1F0B9BE1-B10D-4BC9-9B58-1316630E8DD4}";


#region Boilerplate CustomItem Code

public NavigationBaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator NavigationBaseItem(Item innerItem)
{
	return innerItem != null ? new NavigationBaseItem(innerItem) : null;
}

public static implicit operator Item(NavigationBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField NavigationTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Navigation Title"]);
	}
}

public static string FieldName_NavigationTitle 
{
	get
	{
		return "Navigation Title";
	}
} 


public CustomCheckboxField IncludeinTopNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Include in Top Navigation"]);
	}
}

public static string FieldName_IncludeinTopNavigation 
{
	get
	{
		return "Include in Top Navigation";
	}
} 


public CustomCheckboxField IncludeinBottomNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Include in Bottom Navigation"]);
	}
}

public static string FieldName_IncludeinBottomNavigation 
{
	get
	{
		return "Include in Bottom Navigation";
	}
} 


public CustomCheckboxField IncludeinSideNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Include in Side Navigation"]);
	}
}

public static string FieldName_IncludeinSideNavigation 
{
	get
	{
		return "Include in Side Navigation";
	}
} 


#endregion //Field Instance Methods
}
}