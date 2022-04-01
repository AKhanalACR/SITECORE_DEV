using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Widgets
{
public partial class LatestNewsItem : CustomItem
{

public static readonly string TemplateId = "{A077F191-22B1-4F3A-B788-73A1455650B3}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public LatestNewsItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator LatestNewsItem(Item innerItem)
{
	return innerItem != null ? new LatestNewsItem(innerItem) : null;
}

public static implicit operator Item(LatestNewsItem customItem)
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


public CustomImageField Icon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon"]);
	}
}

public static string FieldName_Icon 
{
	get
	{
		return "Icon";
	}
} 


public CustomIntegerField NumberofStories
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Number of Stories"]);
	}
}

public static string FieldName_NumberofStories 
{
	get
	{
		return "Number of Stories";
	}
} 


#endregion //Field Instance Methods
}
}