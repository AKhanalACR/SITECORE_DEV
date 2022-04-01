using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Widgets;

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class LoginWidgetItem : CustomItem
{

public static readonly string TemplateId = "{1A713A05-B3EB-48F9-8D29-185CAB4C7DC5}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public LoginWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator LoginWidgetItem(Item innerItem)
{
	return innerItem != null ? new LoginWidgetItem(innerItem) : null;
}

public static implicit operator Item(LoginWidgetItem customItem)
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


public CustomGeneralLinkField SecondaryWidgetLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Secondary Widget Link"]);
	}
}


#endregion //Field Instance Methods
}
}