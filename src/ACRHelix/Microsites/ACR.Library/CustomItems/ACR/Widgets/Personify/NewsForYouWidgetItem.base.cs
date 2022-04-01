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
public partial class NewsForYouWidgetItem : CustomItem
{

public static readonly string TemplateId = "{B5FC01F1-D660-4365-8C99-77080980B062}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public NewsForYouWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator NewsForYouWidgetItem(Item innerItem)
{
	return innerItem != null ? new NewsForYouWidgetItem(innerItem) : null;
}

public static implicit operator Item(NewsForYouWidgetItem customItem)
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


public CustomGeneralLinkField DetailLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Detail Link"]);
	}
}

public static string FieldName_DetailLink 
{
	get
	{
		return "Detail Link";
	}
} 


#endregion //Field Instance Methods
}
}