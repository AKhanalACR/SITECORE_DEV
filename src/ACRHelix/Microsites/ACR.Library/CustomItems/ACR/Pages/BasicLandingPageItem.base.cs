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

namespace ACR.Library.ACR.Pages
{
public partial class BasicLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{011B93EB-FDBB-41D6-9D3F-A4C9E4CD72F6}";

#region Inherited Base Templates

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

public BasicLandingPageItem(Item innerItem) : base(innerItem)
{
	_BaseContentItem = new BaseContentItem(innerItem);
	_EducationCenterFeatureItem = new EducationCenterFeatureItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_RelatedDocumentsPageItem = new RelatedDocumentsPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);

}

public static implicit operator BasicLandingPageItem(Item innerItem)
{
	return innerItem != null ? new BasicLandingPageItem(innerItem) : null;
}

public static implicit operator Item(BasicLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField ShowAccordion
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show Accordion"]);
	}
}


#endregion //Field Instance Methods
}
}