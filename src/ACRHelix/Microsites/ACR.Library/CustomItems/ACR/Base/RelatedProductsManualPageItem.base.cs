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
public partial class RelatedProductsManualPageItem : CustomItem
{

public static readonly string TemplateId = "{D505D65C-DC40-4A4D-AB06-5BA5E8886386}";


#region Boilerplate CustomItem Code

public RelatedProductsManualPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RelatedProductsManualPageItem(Item innerItem)
{
	return innerItem != null ? new RelatedProductsManualPageItem(innerItem) : null;
}

public static implicit operator Item(RelatedProductsManualPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FeaturedProductsManualHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Products Manual Header"]);
	}
}


public CustomTreeListField FeaturedProductsManual
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Products Manual"]);
	}
}


#endregion //Field Instance Methods
}
}