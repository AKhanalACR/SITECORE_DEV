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
public partial class _hasOnlineProviderResourcesModuleItem : CustomItem
{

public static readonly string TemplateId = "{0CB84002-874A-4D1B-B03B-599D14DD3D83}";


#region Boilerplate CustomItem Code

public _hasOnlineProviderResourcesModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasOnlineProviderResourcesModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasOnlineProviderResourcesModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasOnlineProviderResourcesModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField OnlineProviderResourcesTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Online Provider Resources Title"]);
	}
}


public CustomMultiListField OnlineProviderResources
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Online Provider Resources"]);
	}
}


#endregion //Field Instance Methods
}
}