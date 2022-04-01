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
public partial class MembershipRenewalNoticeWidgetItem : CustomItem
{

public static readonly string TemplateId = "{2865C679-EFDC-493A-A22D-D8C6ADB96E93}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public MembershipRenewalNoticeWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator MembershipRenewalNoticeWidgetItem(Item innerItem)
{
	return innerItem != null ? new MembershipRenewalNoticeWidgetItem(innerItem) : null;
}

public static implicit operator Item(MembershipRenewalNoticeWidgetItem customItem)
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


public CustomTextField RenewalLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Renewal Link Text"]);
	}
}

public static string FieldName_RenewalLinkText 
{
	get
	{
		return "Renewal Link Text";
	}
} 


#endregion //Field Instance Methods
}
}