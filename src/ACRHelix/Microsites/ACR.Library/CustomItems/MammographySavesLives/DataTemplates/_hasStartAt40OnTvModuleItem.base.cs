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
public partial class _hasStartAt40OnTvModuleItem : CustomItem
{

public static readonly string TemplateId = "{D28F8B87-5A8F-4DBA-ADB5-8D34C88C2B5F}";


#region Boilerplate CustomItem Code

public _hasStartAt40OnTvModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasStartAt40OnTvModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasStartAt40OnTvModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasStartAt40OnTvModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField StartAt40Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Start At 40 Title"]);
	}
}


public CustomTextField StartAt40Intro
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Start At 40 Intro"]);
	}
}


public CustomMultiListField StartAt40Videos
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Start At 40 Videos"]);
	}
}


#endregion //Field Instance Methods
}
}