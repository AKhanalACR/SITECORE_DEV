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
public partial class PhysiciansMediaItem : CustomItem
{
public static readonly string TemplateId = "{1D1FB00E-CAE7-4038-A0AC-C3482E84FA60}";

#region Boilerplate CustomItem Code

public PhysiciansMediaItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PhysiciansMediaItem(Item innerItem)
{
	return innerItem != null ? new PhysiciansMediaItem(innerItem) : null;
}

public static implicit operator Item(PhysiciansMediaItem customItem)
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