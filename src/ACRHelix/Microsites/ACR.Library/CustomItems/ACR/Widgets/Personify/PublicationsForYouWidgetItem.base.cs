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

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class PublicationsForYouWidgetItem : CustomItem
{

public static readonly string TemplateId = "{E89FA1B6-52E9-4BCD-96D6-673A711B5D7F}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public PublicationsForYouWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator PublicationsForYouWidgetItem(Item innerItem)
{
	return innerItem != null ? new PublicationsForYouWidgetItem(innerItem) : null;
}

public static implicit operator Item(PublicationsForYouWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}

public static string FieldName_Title 
{
	get
	{
		return "Title";
	}
} 


#endregion //Field Instance Methods
}
}