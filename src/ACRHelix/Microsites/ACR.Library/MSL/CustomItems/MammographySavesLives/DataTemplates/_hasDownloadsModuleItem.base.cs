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
public partial class _hasDownloadsModuleItem : CustomItem
{
public static readonly string TemplateId = "{B3142123-D37F-4B2B-A3D9-2B59CCC4A884}";

#region Boilerplate CustomItem Code

public _hasDownloadsModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasDownloadsModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasDownloadsModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasDownloadsModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FirstSectionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["First Section Title"]);
	}
}


public CustomTextField FirstSectionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["First Section Text"]);
	}
}


public CustomTextField SecondSectionTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Second Section Title"]);
	}
}


public CustomTextField SecondSectionText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Second Section Text"]);
	}
}


public CustomMultiListField DownloadVideos
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Download Videos"]);
	}
}


#endregion //Field Instance Methods
}
}