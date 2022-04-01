using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Pages
{
public partial class ErrorPageItem : CustomItem
{

public static readonly string TemplateId = "{E68C7B1A-A5E8-4EF6-ABEF-07290D0D7683}";

#region Inherited Base Templates

private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ErrorPageItem(Item innerItem) : base(innerItem)
{
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_BasePageItem = new BasePageItem(innerItem);

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


#endregion //Field Instance Methods
}
}