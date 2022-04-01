using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Widgets;

namespace ACR.Library.ACR.Widgets.Global
{
public partial class HeaderBannerAdItem : CustomItem
{

public static readonly string TemplateId = "{BFAC4E3A-0751-4CD0-8714-3193103E8A28}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public HeaderBannerAdItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator HeaderBannerAdItem(Item innerItem)
{
	return innerItem != null ? new HeaderBannerAdItem(innerItem) : null;
}

public static implicit operator Item(HeaderBannerAdItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AdvertisementJavaScript
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Advertisement JavaScript"]);
	}
}


public CustomTreeListField ExclusionItems
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Exclusion Items"]);
	}
}


#endregion //Field Instance Methods
}
}