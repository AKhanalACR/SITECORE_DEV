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

namespace ACR.Library.ACR.CodingSource
{
public partial class CodingSourceListItem : CustomItem
{

public static readonly string TemplateId = "{3BA50C0C-D4E5-4FED-A5E0-C2DE1370A653}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly RelatedDocumentsPageItem _RelatedDocumentsPageItem;
public RelatedDocumentsPageItem RelatedDocumentsPage { get { return _RelatedDocumentsPageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CodingSourceListItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_RelatedDocumentsPageItem = new RelatedDocumentsPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);

}

public static implicit operator CodingSourceListItem(Item innerItem)
{
	return innerItem != null ? new CodingSourceListItem(innerItem) : null;
}

public static implicit operator Item(CodingSourceListItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}