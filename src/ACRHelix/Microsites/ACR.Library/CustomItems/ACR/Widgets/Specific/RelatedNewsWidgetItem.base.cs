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
public partial class RelatedNewsWidgetItem : CustomItem
{

public static readonly string TemplateId = "{F9D84D4D-C534-4B8D-B8D4-E09BA062DA9F}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RelatedNewsWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator RelatedNewsWidgetItem(Item innerItem)
{
	return innerItem != null ? new RelatedNewsWidgetItem(innerItem) : null;
}

public static implicit operator Item(RelatedNewsWidgetItem customItem)
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


public CustomTextField LinkTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Title"]);
	}
}

public static string FieldName_LinkTitle 
{
	get
	{
		return "Link Title";
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