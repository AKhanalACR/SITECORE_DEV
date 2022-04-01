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
public partial class FeaturedSectionLinkItem : CustomItem
{

public static readonly string TemplateId = "{C5BFBA8B-AF2E-45DD-B1FA-7D438DBD03F1}";


#region Boilerplate CustomItem Code

public FeaturedSectionLinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FeaturedSectionLinkItem(Item innerItem)
{
	return innerItem != null ? new FeaturedSectionLinkItem(innerItem) : null;
}

public static implicit operator Item(FeaturedSectionLinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField FeaturedSection
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Featured Section"]);
	}
}

public static string FieldName_FeaturedSection 
{
	get
	{
		return "Featured Section";
	}
} 


public CustomTextField FeaturedSectionTitleOverride
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Section Title Override"]);
	}
}

public static string FieldName_FeaturedSectionTitleOverride 
{
	get
	{
		return "Featured Section Title Override";
	}
} 


public CustomImageField FeaturedSectionImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Featured Section Image"]);
	}
}

public static string FieldName_FeaturedSectionImage 
{
	get
	{
		return "Featured Section Image";
	}
} 


public CustomTextField FeaturedSectionLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Section Link Text"]);
	}
}

public static string FieldName_FeaturedSectionLinkText 
{
	get
	{
		return "Featured Section Link Text";
	}
} 


#endregion //Field Instance Methods
}
}