using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Widgets.General
{
public partial class ResourceWidgetItem : CustomItem
{

public static readonly string TemplateId = "{0587F010-B431-45A0-AB98-E2F150716D2E}";


#region Boilerplate CustomItem Code

public ResourceWidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ResourceWidgetItem(Item innerItem)
{
	return innerItem != null ? new ResourceWidgetItem(innerItem) : null;
}

public static implicit operator Item(ResourceWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}

public static string FieldName_Title 
{
	get
	{
		return "Title";
	}
} 


public CustomTreeListField Resources
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Resources"]);
	}
}

public static string FieldName_Resources 
{
	get
	{
		return "Resources";
	}
} 


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}

public static string FieldName_Link 
{
	get
	{
		return "Link";
	}
} 


public CustomTextField LinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Text"]);
	}
}

public static string FieldName_LinkText 
{
	get
	{
		return "Link Text";
	}
} 


#endregion //Field Instance Methods
}
}