using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Widgets;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class RelatedProductsWidgetItem : CustomItem
{

public static readonly string TemplateId = "{B77E6ED1-F75D-4497-9F9D-33CCC8664598}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RelatedProductsWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator RelatedProductsWidgetItem(Item innerItem)
{
	return innerItem != null ? new RelatedProductsWidgetItem(innerItem) : null;
}

public static implicit operator Item(RelatedProductsWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TaxonomyType
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Taxonomy Type"]);
	}
}

public static string FieldName_TaxonomyType 
{
	get
	{
		return "Taxonomy Type";
	}
} 


#endregion //Field Instance Methods
}
}