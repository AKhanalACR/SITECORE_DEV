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
public partial class _hasVideoDownloadsModuleItem : CustomItem
{

public static readonly string TemplateId = "{B5E2A050-6559-4824-98A3-88F8861B4AA3}";


#region Boilerplate CustomItem Code

public _hasVideoDownloadsModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasVideoDownloadsModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasVideoDownloadsModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasVideoDownloadsModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField VideoDownloadsIntro
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Downloads Intro"]);
	}
}


public CustomTextField VideoDownloadsTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Downloads Title"]);
	}
}


public CustomMultiListField VideoDownloads
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Video Downloads"]);
	}
}


#endregion //Field Instance Methods
}
}