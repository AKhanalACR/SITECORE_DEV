using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Widgets;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class LatestNewsWidgetItem : CustomItem
{

public static readonly string TemplateId = "{FCE00380-A005-4147-A309-85027507458C}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public LatestNewsWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator LatestNewsWidgetItem(Item innerItem)
{
	return innerItem != null ? new LatestNewsWidgetItem(innerItem) : null;
}

public static implicit operator Item(LatestNewsWidgetItem customItem)
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


public CustomTextField LinkTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Title"]);
	}
}

public static string FieldName_LinkTitle 
{
	get
	{
		return "Link Title";
	}
} 


public CustomLookupField NewsCategory
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["News Category"]);
	}
}

public static string FieldName_NewsCategory 
{
	get
	{
		return "News Category";
	}
} 


public CustomGeneralLinkField NewsPageLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["News Page Link"]);
	}
}

public static string FieldName_NewsPageLink 
{
	get
	{
		return "News Page Link";
	}
} 


#endregion //Field Instance Methods
}
}