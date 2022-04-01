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

namespace ACR.Library.ACR.FAQ
{
public partial class FAQPageItem : CustomItem
{

public static readonly string TemplateId = "{FACA5D1B-FA5C-4643-9938-338454F581B9}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public FAQPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator FAQPageItem(Item innerItem)
{
	return innerItem != null ? new FAQPageItem(innerItem) : null;
}

public static implicit operator Item(FAQPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField FAQType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["FAQ Type"]);
	}
}

public static string FieldName_FAQType 
{
	get
	{
		return "FAQ Type";
	}
} 


#endregion //Field Instance Methods
}
}