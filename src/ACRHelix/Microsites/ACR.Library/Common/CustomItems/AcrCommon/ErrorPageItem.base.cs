using System;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.Common.CustomItems.AcrCommon
{
public partial class ErrorPageItem : CustomItem
{

public static readonly string TemplateId = "{5101A479-219D-4FE0-9879-A1417CE4318B}";

#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }

#endregion

#region Boilerplate CustomItem Code

public ErrorPageItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);

}

public static implicit operator ErrorPageItem(Item innerItem)
{
	return innerItem != null ? new ErrorPageItem(innerItem) : null;
}

public static implicit operator Item(ErrorPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ErrorMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Error Message"]);
	}
}

public static string FieldName_ErrorMessage 
{
	get
	{
		return "Error Message";
	}
} 


#endregion //Field Instance Methods
}
}