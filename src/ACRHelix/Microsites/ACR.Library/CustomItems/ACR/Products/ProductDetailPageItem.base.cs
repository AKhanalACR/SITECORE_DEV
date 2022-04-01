using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Products
{
public partial class ProductDetailPageItem : CustomItem
{

public static readonly string TemplateId = "{68F88DA3-8ADB-4535-A9F2-BD3CEB7B358A}";

#region Inherited Base Templates

private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ProductDetailPageItem(Item innerItem) : base(innerItem)
{
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_BasePageItem = new BasePageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);

}

public static implicit operator ProductDetailPageItem(Item innerItem)
{
	return innerItem != null ? new ProductDetailPageItem(innerItem) : null;
}

public static implicit operator Item(ProductDetailPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}