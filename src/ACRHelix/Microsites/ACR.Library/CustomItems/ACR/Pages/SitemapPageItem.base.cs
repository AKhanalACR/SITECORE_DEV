using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Pages
{
public partial class SitemapPageItem : CustomItem
{

public static readonly string TemplateId = "{BF19F307-6B5F-4354-8049-2A53DD0248D5}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SitemapPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);

}

public static implicit operator SitemapPageItem(Item innerItem)
{
	return innerItem != null ? new SitemapPageItem(innerItem) : null;
}

public static implicit operator Item(SitemapPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField SectionOrder
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Section Order"]);
	}
}

public static string FieldName_SectionOrder 
{
	get
	{
		return "Section Order";
	}
} 


#endregion //Field Instance Methods
}
}