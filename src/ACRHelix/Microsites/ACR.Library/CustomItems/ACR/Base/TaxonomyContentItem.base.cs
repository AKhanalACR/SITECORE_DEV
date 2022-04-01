using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.Base
{
public partial class TaxonomyContentItem : CustomItem
{

public static readonly string TemplateId = "{8BE6148F-8657-4756-BCBE-DF824F90C04C}";


#region Boilerplate CustomItem Code

public TaxonomyContentItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TaxonomyContentItem(Item innerItem)
{
	return innerItem != null ? new TaxonomyContentItem(innerItem) : null;
}

public static implicit operator Item(TaxonomyContentItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField RelatedModalities
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Modalities"]);
	}
}

public static string FieldName_RelatedModalities 
{
	get
	{
		return "Related Modalities";
	}
} 


public CustomTreeListField RelatedSubspecialites
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Subspecialites"]);
	}
}

public static string FieldName_RelatedSubspecialites 
{
	get
	{
		return "Related Subspecialites";
	}
} 


public CustomTreeListField RelatedInterests
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Interests"]);
	}
}

public static string FieldName_RelatedInterests 
{
	get
	{
		return "Related Interests";
	}
} 


#endregion //Field Instance Methods
}
}