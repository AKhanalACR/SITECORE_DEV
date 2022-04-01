using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Base
{
public partial class RelatedProductsPageItem : CustomItem
{

public static readonly string TemplateId = "{4CE59B33-C854-4C02-88DB-1148D3534D2C}";


#region Boilerplate CustomItem Code

public RelatedProductsPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RelatedProductsPageItem(Item innerItem)
{
	return innerItem != null ? new RelatedProductsPageItem(innerItem) : null;
}

public static implicit operator Item(RelatedProductsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FeaturedProductsHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Products Header"]);
	}
}

public static string FieldName_FeaturedProductsHeader 
{
	get
	{
		return "Featured Products Header";
	}
} 


public CustomTreeListField FeaturedProducts
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Products"]);
	}
}

public static string FieldName_FeaturedProducts 
{
	get
	{
		return "Featured Products";
	}
} 


#endregion //Field Instance Methods
}
}