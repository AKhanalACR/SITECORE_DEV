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
public partial class MyProfileWidgetItem : CustomItem
{

public static readonly string TemplateId = "{F8D469ED-A131-4591-9C12-AA05E8C203BD}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public MyProfileWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator MyProfileWidgetItem(Item innerItem)
{
	return innerItem != null ? new MyProfileWidgetItem(innerItem) : null;
}

public static implicit operator Item(MyProfileWidgetItem customItem)
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


public CustomGeneralLinkField RenewLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Renew Link"]);
	}
}

public static string FieldName_RenewLink 
{
	get
	{
		return "Renew Link";
	}
} 


public CustomGeneralLinkField EditLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Edit Link"]);
	}
}

public static string FieldName_EditLink 
{
	get
	{
		return "Edit Link";
	}
} 


public CustomGeneralLinkField MyEducationLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["My Education Link"]);
	}
}

public static string FieldName_MyEducationLink 
{
	get
	{
		return "My Education Link";
	}
} 


public CustomGeneralLinkField CMEGatewayLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["CME Gateway Link"]);
	}
}

public static string FieldName_CMEGatewayLink 
{
	get
	{
		return "CME Gateway Link";
	}
} 


public CustomTextField CreditsLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Credits Label"]);
	}
}

public static string FieldName_CreditsLabel 
{
	get
	{
		return "Credits Label";
	}
} 


#endregion //Field Instance Methods
}
}