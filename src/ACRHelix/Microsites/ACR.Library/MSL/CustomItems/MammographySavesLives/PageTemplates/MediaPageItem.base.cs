using System;
using ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.PageTemplates
{
public partial class MediaPageItem : CustomItem
{
public static readonly string TemplateId = "{72E057E0-D163-4414-9000-4A9E26F0FAD0}";
#region Inherited Base Templates

private readonly DetailPageItem _DetailPageItem;
public DetailPageItem DetailPage { get { return _DetailPageItem; } }
private readonly _hasDownloadsModuleItem __hasDownloadsModuleItem;
public _hasDownloadsModuleItem hasDownloadsModule { get { return __hasDownloadsModuleItem; } }
private readonly _hasPhysiciansModuleItem __hasPhysiciansModuleItem;
public _hasPhysiciansModuleItem hasPhysiciansModule { get { return __hasPhysiciansModuleItem; } }
private readonly _hasNewsReleasesItem __hasNewsReleasesItem;
public _hasNewsReleasesItem hasNewsReleases { get { return __hasNewsReleasesItem; } }

#endregion

#region Boilerplate CustomItem Code

public MediaPageItem(Item innerItem) : base(innerItem)
{
	_DetailPageItem = new DetailPageItem(innerItem);
	__hasDownloadsModuleItem = new _hasDownloadsModuleItem(innerItem);
	__hasPhysiciansModuleItem = new _hasPhysiciansModuleItem(innerItem);
	__hasNewsReleasesItem = new _hasNewsReleasesItem(innerItem);

}

public static implicit operator MediaPageItem(Item innerItem)
{
	return innerItem != null ? new MediaPageItem(innerItem) : null;
}

public static implicit operator Item(MediaPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}