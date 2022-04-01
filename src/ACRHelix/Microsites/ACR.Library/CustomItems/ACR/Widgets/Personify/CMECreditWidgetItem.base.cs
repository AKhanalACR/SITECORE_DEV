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
public partial class CMECreditWidgetItem : CustomItem
{

public static readonly string TemplateId = "{06B261EC-640B-4CBD-A234-54D33CC26F19}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public CMECreditWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator CMECreditWidgetItem(Item innerItem)
{
	return innerItem != null ? new CMECreditWidgetItem(innerItem) : null;
}

public static implicit operator Item(CMECreditWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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


public CustomGeneralLinkField MyAccountLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["My Account Link"]);
	}
}

public static string FieldName_MyAccountLink 
{
	get
	{
		return "My Account Link";
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