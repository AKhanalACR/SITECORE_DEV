using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.News
{
public partial class NewsCategoryListPageItem : CustomItem
{

public static readonly string TemplateId = "{634A20A2-3A1C-4464-9E71-33C0DB9D1ABE}";

#region Inherited Base Templates

private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public NewsCategoryListPageItem(Item innerItem) : base(innerItem)
{
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_BasePageItem = new BasePageItem(innerItem);

}

public static implicit operator NewsCategoryListPageItem(Item innerItem)
{
	return innerItem != null ? new NewsCategoryListPageItem(innerItem) : null;
}

public static implicit operator Item(NewsCategoryListPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField ArticleType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Article Type"]);
	}
}

public static string FieldName_ArticleType 
{
	get
	{
		return "Article Type";
	}
} 


#endregion //Field Instance Methods
}
}