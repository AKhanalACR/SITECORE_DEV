using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class ResearchItem : CustomItem
{
public static readonly string TemplateId = "{1EA42F5A-2BA7-441C-8649-4B0007563D31}";

#region Boilerplate CustomItem Code

public ResearchItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ResearchItem(Item innerItem)
{
	return innerItem != null ? new ResearchItem(innerItem) : null;
}

public static implicit operator Item(ResearchItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ResearchTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Research Title"]);
	}
}


public CustomTextField ResearchAuthor
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Research Author"]);
	}
}


public CustomGeneralLinkField ResearchLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Research Link"]);
	}
}


public CustomMultiListField ResearchIcon
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Research Icon"]);
	}
}


public CustomFileField ResearchFile
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Research File"]);
	}
}


#endregion //Field Instance Methods
}
}