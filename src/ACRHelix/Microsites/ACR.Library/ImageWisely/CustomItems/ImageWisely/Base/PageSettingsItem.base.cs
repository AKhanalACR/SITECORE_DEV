using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Base
{
public partial class PageSettingsItem : CustomItem
{
public static readonly string TemplateId = "{26931C5E-6F46-40D9-BF88-194BF1B15FCB}";

#region Boilerplate CustomItem Code

public PageSettingsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PageSettingsItem(Item innerItem)
{
	return innerItem != null ? new PageSettingsItem(innerItem) : null;
}

public static implicit operator Item(PageSettingsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField DisplayinAuxiliaryNav
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display in Auxiliary Nav"]);
	}
}


public CustomTextField PageTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Page Title"]);
	}
}


public CustomCheckboxField DisplayinMainNav
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display in Main Nav"]);
	}
}


public CustomCheckboxField SuppressPageTitleSuffix
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Suppress Page Title Suffix"]);
	}
}


public CustomCheckboxField DisplayinFooterNav
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display in Footer Nav"]);
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