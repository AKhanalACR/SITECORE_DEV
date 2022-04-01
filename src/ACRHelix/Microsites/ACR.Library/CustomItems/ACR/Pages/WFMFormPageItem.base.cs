using System;
using ACR.Library.CustomItems.ACR.Pages;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.CustomItems.ACR.Pages
{
public partial class WFMFormPageItem : CustomItem
{

public static readonly string TemplateId = "{6B880E89-9398-45F6-A14B-421B658ABB22}";

#region Inherited Base Templates

private readonly BasicContentPageItem _BasicContentPageItem;
public BasicContentPageItem BasicContentPage { get { return _BasicContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public WFMFormPageItem(Item innerItem) : base(innerItem)
{
	_BasicContentPageItem = new BasicContentPageItem(innerItem);

}

public static implicit operator WFMFormPageItem(Item innerItem)
{
	return innerItem != null ? new WFMFormPageItem(innerItem) : null;
}

public static implicit operator Item(WFMFormPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}