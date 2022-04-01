using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MammographySavesLives.ContentItems
{
public partial class MarketingMaterialItem : CustomItem
{

public static readonly string TemplateId = "{F64A099B-4B08-4F05-A90B-7EE12CA76D1B}";


#region Boilerplate CustomItem Code

public MarketingMaterialItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator MarketingMaterialItem(Item innerItem)
{
	return innerItem != null ? new MarketingMaterialItem(innerItem) : null;
}

public static implicit operator Item(MarketingMaterialItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PrintMediaTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Print Media Title"]);
	}
}


public CustomTextField LowResTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Low Res Title"]);
	}
}


public CustomFileField LowResFile
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Low Res File"]);
	}
}


public CustomTextField HiResTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hi Res Title"]);
	}
}


public CustomFileField HiResFile
{
	get
	{
		return new CustomFileField(InnerItem, InnerItem.Fields["Hi Res File"]);
	}
}


#endregion //Field Instance Methods
}
}