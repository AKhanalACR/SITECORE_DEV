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
public partial class NewsReleaseItem : CustomItem
{
public static readonly string TemplateId = "{207D8E49-DDC2-4B17-AB08-B5F76F5C7D94}";

#region Boilerplate CustomItem Code

public NewsReleaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator NewsReleaseItem(Item innerItem)
{
	return innerItem != null ? new NewsReleaseItem(innerItem) : null;
}

public static implicit operator Item(NewsReleaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField NewsReleaseTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["News Release Title"]);
	}
}


public CustomGeneralLinkField NewsReleaseLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["News Release Link"]);
	}
}


public CustomMultiListField IconSelect
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Icon Select"]);
	}
}


public CustomFileField NewsReleaseFile
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["News Release File"]);
	}
}


#endregion //Field Instance Methods
}
}