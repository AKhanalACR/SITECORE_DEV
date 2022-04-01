using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Pages
{
public partial class ErrorPageItem : CustomItem
{

public static readonly string TemplateId = "{08E759C3-4397-4A21-88EB-1223C9DBC59E}";

#region Inherited Base Templates

private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }
private readonly BackgroundBaseItem _BackgroundBaseItem;
public BackgroundBaseItem BackgroundBase { get { return _BackgroundBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public ErrorPageItem(Item innerItem) : base(innerItem)
{
	_PageBaseItem = new PageBaseItem(innerItem);
	_BackgroundBaseItem = new BackgroundBaseItem(innerItem);

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