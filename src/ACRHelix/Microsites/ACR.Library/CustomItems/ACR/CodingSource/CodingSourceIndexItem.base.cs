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
public partial class CodingSourceIndexItem : CustomItem
{

public static readonly string TemplateId = "{D7F55495-508C-42EB-B273-9D28B9BCEF44}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }
private readonly RelatedDocumentsPageItem _RelatedDocumentsPageItem;
public RelatedDocumentsPageItem RelatedDocumentsPage { get { return _RelatedDocumentsPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CodingSourceIndexItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);
	_RelatedDocumentsPageItem = new RelatedDocumentsPageItem(innerItem);

}

public static implicit operator CodingSourceIndexItem(Item innerItem)
{
	return innerItem != null ? new CodingSourceIndexItem(innerItem) : null;
}

public static implicit operator Item(CodingSourceIndexItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomDateField PublicationDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Publication Date"]);
	}
}

public static string FieldName_PublicationDate 
{
	get
	{
		return "Publication Date";
	}
} 


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}

public static string FieldName_Image 
{
	get
	{
		return "Image";
	}
} 


public CustomLookupField PDFVersion
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["PDF Version"]);
	}
}

public static string FieldName_PDFVersion 
{
	get
	{
		return "PDF Version";
	}
} 


#endregion //Field Instance Methods
}
}