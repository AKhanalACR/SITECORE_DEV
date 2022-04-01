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
public partial class FAQWidgetItem : CustomItem
{

public static readonly string TemplateId = "{C56D2CA8-FF34-4A4E-8F25-274C13FF8EB1}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public FAQWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator FAQWidgetItem(Item innerItem)
{
	return innerItem != null ? new FAQWidgetItem(innerItem) : null;
}

public static implicit operator Item(FAQWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField HeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Text"]);
	}
}

public static string FieldName_HeaderText 
{
	get
	{
		return "Header Text";
	}
} 


public CustomLookupField FAQsType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["FAQs Type"]);
	}
}

public static string FieldName_FAQsType 
{
	get
	{
		return "FAQs Type";
	}
} 


public CustomTextField ViewAllLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["View All Link Text"]);
	}
}

public static string FieldName_ViewAllLinkText 
{
	get
	{
		return "View All Link Text";
	}
} 


public CustomGeneralLinkField ViewAllLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["View All Link"]);
	}
}

public static string FieldName_ViewAllLink 
{
	get
	{
		return "View All Link";
	}
} 


#endregion //Field Instance Methods
}
}