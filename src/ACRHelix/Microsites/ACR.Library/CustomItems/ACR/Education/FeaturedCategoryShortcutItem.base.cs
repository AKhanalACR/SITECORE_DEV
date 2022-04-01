using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Education
{
public partial class FeaturedCategoryShortcutItem : CustomItem
{

public static readonly string TemplateId = "{385DB3E4-C4FE-4F8C-9616-453E2685E323}";


#region Boilerplate CustomItem Code

public FeaturedCategoryShortcutItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FeaturedCategoryShortcutItem(Item innerItem)
{
	return innerItem != null ? new FeaturedCategoryShortcutItem(innerItem) : null;
}

public static implicit operator Item(FeaturedCategoryShortcutItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField ProductCategory
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Product Category"]);
	}
}

public static string FieldName_ProductCategory 
{
	get
	{
		return "Product Category";
	}
} 


public CustomImageField ProductCategoryImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Product Category Image"]);
	}
}

public static string FieldName_ProductCategoryImage 
{
	get
	{
		return "Product Category Image";
	}
} 


#endregion //Field Instance Methods
}
}