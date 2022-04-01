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

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class RecommendedMeetingsWidgetItem : CustomItem
{

public static readonly string TemplateId = "{2D695F52-633F-40F5-B4A9-683FE1CF9159}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RecommendedMeetingsWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator RecommendedMeetingsWidgetItem(Item innerItem)
{
	return innerItem != null ? new RecommendedMeetingsWidgetItem(innerItem) : null;
}

public static implicit operator Item(RecommendedMeetingsWidgetItem customItem)
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


public CustomTextField TaxonomyType
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Taxonomy Type"]);
	}
}

public static string FieldName_TaxonomyType 
{
	get
	{
		return "Taxonomy Type";
	}
} 


#endregion //Field Instance Methods
}
}