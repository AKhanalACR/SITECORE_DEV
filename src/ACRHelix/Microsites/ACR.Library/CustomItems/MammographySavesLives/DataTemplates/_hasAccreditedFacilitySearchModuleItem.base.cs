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
public partial class _hasAccreditedFacilitySearchModuleItem : CustomItem
{

public static readonly string TemplateId = "{DEF992B6-102C-44C5-9A93-730574F9F60D}";


#region Boilerplate CustomItem Code

public _hasAccreditedFacilitySearchModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasAccreditedFacilitySearchModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasAccreditedFacilitySearchModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasAccreditedFacilitySearchModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ModuleTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Module Title"]);
	}
}


public CustomImageField ModuleImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Module Image"]);
	}
}


public CustomTextField ModuleText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Module Text"]);
	}
}


#endregion //Field Instance Methods
}
}