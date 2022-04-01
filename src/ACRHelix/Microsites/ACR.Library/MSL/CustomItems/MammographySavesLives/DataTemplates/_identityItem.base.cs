using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates
{
public partial class _identityItem : CustomItem
{
public static readonly string TemplateId = "{43963C28-FCE0-4DD6-B14F-56FD7D24C7AF}";

#region Boilerplate CustomItem Code

public _identityItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _identityItem(Item innerItem)
{
	return innerItem != null ? new _identityItem(innerItem) : null;
}

public static implicit operator Item(_identityItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField CopyrightIntro
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Copyright Intro"]);
	}
}


public CustomTextField CopyrightNotice
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Copyright Notice"]);
	}
}


public CustomMultiListField FooterNavigation
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Footer Navigation"]);
	}
}


public CustomImageField Logo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Logo"]);
	}
}


public CustomTextField SiteTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Site Title"]);
	}
}


public CustomMultiListField FooterImageLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Footer Image Links"]);
	}
}


public CustomLookupField UtilityNavigation
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Utility Navigation"]);
	}
}


public CustomMultiListField FooterSocialMediaIcons
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Footer Social Media Icons"]);
	}
}


public CustomMultiListField HeaderSocialMediaIcons
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Header Social Media Icons"]);
	}
}


#endregion //Field Instance Methods
}
}