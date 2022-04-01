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
public partial class FeaturedContentItem : CustomItem
{

public static readonly string TemplateId = "{946A673E-E013-4B24-8A07-E57A4BFF0BBF}";


#region Boilerplate CustomItem Code

public FeaturedContentItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FeaturedContentItem(Item innerItem)
{
	return innerItem != null ? new FeaturedContentItem(innerItem) : null;
}

public static implicit operator Item(FeaturedContentItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField FeatureImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Feature Image"]);
	}
}


public CustomTextField FeatureTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Feature Title"]);
	}
}


public CustomTextField FeatureDetails
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Feature Details"]);
	}
}


public CustomGeneralLinkField FeatureLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Feature Link"]);
	}
}


#endregion //Field Instance Methods
}
}