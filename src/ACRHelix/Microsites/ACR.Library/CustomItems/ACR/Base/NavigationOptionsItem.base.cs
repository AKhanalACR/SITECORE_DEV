using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Base
{
public partial class NavigationOptionsItem : CustomItem
{

public static readonly string TemplateId = "{8649F60A-AFEA-44FF-B9F4-ED52DBBC6356}";


#region Boilerplate CustomItem Code

public NavigationOptionsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator NavigationOptionsItem(Item innerItem)
{
	return innerItem != null ? new NavigationOptionsItem(innerItem) : null;
}

public static implicit operator Item(NavigationOptionsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField ShowinTopNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show in Top Navigation"]);
	}
}

public static string FieldName_ShowinTopNavigation 
{
	get
	{
		return "Show in Top Navigation";
	}
} 


public CustomCheckboxField ShowinSideNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show in Side Navigation"]);
	}
}

public static string FieldName_ShowinSideNavigation 
{
	get
	{
		return "Show in Side Navigation";
	}
} 


public CustomCheckboxField ShowinFooter
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show in Footer"]);
	}
}

public static string FieldName_ShowinFooter 
{
	get
	{
		return "Show in Footer";
	}
} 


public CustomCheckboxField ShowinSitemap
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show in Sitemap"]);
	}
}

public static string FieldName_ShowinSitemap 
{
	get
	{
		return "Show in Sitemap";
	}
} 


public CustomCheckboxField HideBreadcrumb
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Hide Breadcrumb"]);
	}
}

public static string FieldName_HideBreadcrumb 
{
	get
	{
		return "Hide Breadcrumb";
	}
} 


public CustomCheckboxField HideSideNavigation
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Hide Side Navigation"]);
	}
}

public static string FieldName_HideSideNavigation 
{
	get
	{
		return "Hide Side Navigation";
	}
} 


#endregion //Field Instance Methods
}
}