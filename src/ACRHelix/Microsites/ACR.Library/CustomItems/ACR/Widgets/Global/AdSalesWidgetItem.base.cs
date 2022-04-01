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
public partial class AdSalesWidgetItem : CustomItem
{

public static readonly string TemplateId = "{6C0D3995-FFA5-4EAE-BE05-FFBF7F0964B5}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public AdSalesWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator AdSalesWidgetItem(Item innerItem)
{
	return innerItem != null ? new AdSalesWidgetItem(innerItem) : null;
}

public static implicit operator Item(AdSalesWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField ExclusionItems
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Exclusion Items"]);
	}
}


public CustomMultiListField Includeditems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Included items"]);
	}
}


#endregion //Field Instance Methods
}
}