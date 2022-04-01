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
public partial class WideBodyPageItem : CustomItem
{

public static readonly string TemplateId = "{75BCEBA3-264E-42A1-BE49-554C13D26FB4}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly RelatedDocumentsPageItem _RelatedDocumentsPageItem;
public RelatedDocumentsPageItem RelatedDocumentsPage { get { return _RelatedDocumentsPageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }
private readonly BaseContentItem _BaseContentItem;
public BaseContentItem BaseContent { get { return _BaseContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public WideBodyPageItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_BasePageItem = new BasePageItem(innerItem);
	_RelatedDocumentsPageItem = new RelatedDocumentsPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);
	_BaseContentItem = new BaseContentItem(innerItem);

}

public static implicit operator WideBodyPageItem(Item innerItem)
{
	return innerItem != null ? new WideBodyPageItem(innerItem) : null;
}

public static implicit operator Item(WideBodyPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}