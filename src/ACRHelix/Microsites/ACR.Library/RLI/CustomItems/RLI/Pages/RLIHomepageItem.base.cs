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
public partial class RLIHomepageItem : CustomItem
{

public static readonly string TemplateId = "{384ABD98-2B5B-44A6-B580-82BC591C5080}";

#region Inherited Base Templates

private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }
private readonly WidgetPageBaseItem _WidgetPageBaseItem;
public WidgetPageBaseItem WidgetPageBase { get { return _WidgetPageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RLIHomepageItem(Item innerItem) : base(innerItem)
{
	_PageBaseItem = new PageBaseItem(innerItem);
	_WidgetPageBaseItem = new WidgetPageBaseItem(innerItem);

}

public static implicit operator RLIHomepageItem(Item innerItem)
{
	return innerItem != null ? new RLIHomepageItem(innerItem) : null;
}

public static implicit operator Item(RLIHomepageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField FeaturedContent
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Featured Content"]);
	}
}

public static string FieldName_FeaturedContent 
{
	get
	{
		return "Featured Content";
	}
} 


public CustomMultiListField SlideshowItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Slideshow Items"]);
	}
}

public static string FieldName_SlideshowItems 
{
	get
	{
		return "Slideshow Items";
	}
} 


public CustomTreeListField FeaturedWidgets
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Widgets"]);
	}
}

public static string FieldName_FeaturedWidgets 
{
	get
	{
		return "Featured Widgets";
	}
} 

#endregion //Field Instance Methods
}
}