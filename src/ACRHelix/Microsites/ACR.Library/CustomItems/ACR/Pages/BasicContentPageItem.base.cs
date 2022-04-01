using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;
using ACR.Library.ACR.Meetings;

namespace ACR.Library.CustomItems.ACR.Pages
{
public partial class BasicContentPageItem : CustomItem
{

public static readonly string TemplateId = "{0DF87EAC-2CDE-46EB-B8B7-D68F2F73C4E9}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly BaseContentItem _BaseContentItem;
public BaseContentItem BaseContent { get { return _BaseContentItem; } }
private readonly EducationCenterFeatureItem _EducationCenterFeatureItem;
public EducationCenterFeatureItem EducationCenterFeature { get { return _EducationCenterFeatureItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly RelatedDocumentsPageItem _RelatedDocumentsPageItem;
public RelatedDocumentsPageItem RelatedDocumentsPage { get { return _RelatedDocumentsPageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public BasicContentPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_BaseContentItem = new BaseContentItem(innerItem);
	_EducationCenterFeatureItem = new EducationCenterFeatureItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_RelatedDocumentsPageItem = new RelatedDocumentsPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);

}

public static implicit operator BasicContentPageItem(Item innerItem)
{
	return innerItem != null ? new BasicContentPageItem(innerItem) : null;
}

public static implicit operator Item(BasicContentPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}