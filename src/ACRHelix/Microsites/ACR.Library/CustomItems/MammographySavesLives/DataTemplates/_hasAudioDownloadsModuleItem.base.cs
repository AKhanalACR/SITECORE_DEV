using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MammographySavesLives.DataTemplates
{
public partial class _hasAudioDownloadsModuleItem : CustomItem
{

public static readonly string TemplateId = "{96760E65-595B-416E-9456-BC14A715F6F7}";


#region Boilerplate CustomItem Code

public _hasAudioDownloadsModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasAudioDownloadsModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasAudioDownloadsModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasAudioDownloadsModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AudioDownloadsModuleTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Audio Downloads Module Title"]);
	}
}


public CustomMultiListField AudioDownloadsModuleItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Audio Downloads Module Items"]);
	}
}


#endregion //Field Instance Methods
}
}