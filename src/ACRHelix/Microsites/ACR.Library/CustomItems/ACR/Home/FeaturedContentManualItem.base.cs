using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Home
{
public partial class FeaturedContentManualItem : CustomItem
{

public static readonly string TemplateId = "{58859DC0-7B8D-48C6-AC77-C9503B2CFFF8}";


#region Boilerplate CustomItem Code

public FeaturedContentManualItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FeaturedContentManualItem(Item innerItem)
{
	return innerItem != null ? new FeaturedContentManualItem(innerItem) : null;
}

public static implicit operator Item(FeaturedContentManualItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField ThumbnailImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Thumbnail Image"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField Details
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Details"]);
	}
}


public CustomGeneralLinkField TargetLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Target Link"]);
	}
}


public CustomTextField MoreLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["More Link Text"]);
	}
}


#endregion //Field Instance Methods
}
}