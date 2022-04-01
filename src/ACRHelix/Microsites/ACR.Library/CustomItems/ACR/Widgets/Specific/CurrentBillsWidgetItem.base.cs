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
public partial class CurrentBillsWidgetItem : CustomItem
{

public static readonly string TemplateId = "{A0248120-CD35-40AB-BADD-961AAB4947FD}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public CurrentBillsWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator CurrentBillsWidgetItem(Item innerItem)
{
	return innerItem != null ? new CurrentBillsWidgetItem(innerItem) : null;
}

public static implicit operator Item(CurrentBillsWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField HeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Text"]);
	}
}

public static string FieldName_HeaderText 
{
	get
	{
		return "Header Text";
	}
} 


#endregion //Field Instance Methods
}
}