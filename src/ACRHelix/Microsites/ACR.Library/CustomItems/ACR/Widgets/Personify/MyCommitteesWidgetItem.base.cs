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
public partial class MyCommitteesWidgetItem : CustomItem
{

public static readonly string TemplateId = "{601A4DFB-3182-4D2F-82BA-C79CE16ABA22}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyCommitteesWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator MyCommitteesWidgetItem(Item innerItem)
{
	return innerItem != null ? new MyCommitteesWidgetItem(innerItem) : null;
}

public static implicit operator Item(MyCommitteesWidgetItem customItem)
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