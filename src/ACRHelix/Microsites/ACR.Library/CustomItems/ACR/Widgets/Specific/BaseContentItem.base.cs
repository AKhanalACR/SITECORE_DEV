using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Base
{
public partial class BaseContentItem : CustomItem
{

public static readonly string TemplateId = "{08607897-6B20-4752-A1D6-BBFD2207865F}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly VideoContentItem _VideoContentItem;
public VideoContentItem VideoContent { get { return _VideoContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public BaseContentItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_VideoContentItem = new VideoContentItem(innerItem);

}

public static implicit operator BaseContentItem(Item innerItem)
{
	return innerItem != null ? new BaseContentItem(innerItem) : null;
}

public static implicit operator Item(BaseContentItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField HeaderImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Header Image"]);
	}
}


public static string FieldName_HeaderImage 
{
	get
	{
		return "Header Image";
	}
} 

public CustomCheckboxField ReplaceBannerWithHeaderImage
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Replace Banner With Header Image"]);
	}
}


public CustomImageField ParentPageThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Parent Page Thumbnail"]);
	}
}


public CustomTextField ParentPageIntroText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Parent Page Intro Text"]);
	}
}


public CustomCheckboxField SuppressParentPageFeature
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Suppress Parent Page Feature"]);
	}
}


#endregion //Field Instance Methods
}
}