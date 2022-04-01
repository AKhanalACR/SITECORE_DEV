using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI
{
public partial class RLISiteSettingsItem : CustomItem
{

public static readonly string TemplateId = "{2BFCE05B-C9D5-471B-87FE-0F1DB71D6C92}";


#region Boilerplate CustomItem Code

public RLISiteSettingsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RLISiteSettingsItem(Item innerItem)
{
	return innerItem != null ? new RLISiteSettingsItem(innerItem) : null;
}

public static implicit operator Item(RLISiteSettingsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField FooterButtons
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Footer Buttons"]);
	}
}


public CustomImageField Logo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Logo"]);
	}
}


public CustomTextField CopyrightText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Copyright Text"]);
	}
}


public CustomMultiListField TopLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Top Links"]);
	}
}


public CustomTextField TwitterURL
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Twitter URL"]);
	}
}


public CustomTextField FacebookURL
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Facebook URL"]);
	}
}


#endregion //Field Instance Methods
}
}