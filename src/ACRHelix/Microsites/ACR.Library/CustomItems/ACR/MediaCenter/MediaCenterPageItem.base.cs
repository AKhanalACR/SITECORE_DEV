using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.MediaCenter
{
public partial class MediaCenterPageItem : CustomItem
{

public static readonly string TemplateId = "{BE613100-AB28-4BE1-95C6-22CBAC4709E6}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly BaseContentItem _BaseContentItem;
public BaseContentItem BaseContent { get { return _BaseContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public MediaCenterPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_BaseContentItem = new BaseContentItem(innerItem);

}

public static implicit operator MediaCenterPageItem(Item innerItem)
{
	return innerItem != null ? new MediaCenterPageItem(innerItem) : null;
}

public static implicit operator Item(MediaCenterPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}