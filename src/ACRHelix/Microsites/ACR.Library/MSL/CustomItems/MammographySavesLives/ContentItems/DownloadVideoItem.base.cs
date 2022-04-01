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
public partial class DownloadVideoItem : CustomItem
{
public static readonly string TemplateId = "{36327E10-9BA1-42C3-92C6-D0A8C2DBC3CC}";

#region Boilerplate CustomItem Code

public DownloadVideoItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DownloadVideoItem(Item innerItem)
{
	return innerItem != null ? new DownloadVideoItem(innerItem) : null;
}

public static implicit operator Item(DownloadVideoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField DownloadTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Download Title"]);
	}
}


public CustomGeneralLinkField DownloadLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Download Link"]);
	}
}


public CustomFileField DownloadFile
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Download File"]);
	}
}


#endregion //Field Instance Methods
}
}