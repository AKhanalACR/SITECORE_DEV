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
public partial class AnnualReminderItem : CustomItem
{
public static readonly string TemplateId = "{79B8F44B-49A7-4347-9633-CC941A14327C}";

#region Boilerplate CustomItem Code

public AnnualReminderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AnnualReminderItem(Item innerItem)
{
	return innerItem != null ? new AnnualReminderItem(innerItem) : null;
}

public static implicit operator Item(AnnualReminderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FullName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Full Name"]);
	}
}


public CustomTextField Email
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Email"]);
	}
}


public CustomTextField ZipCode
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Zip Code"]);
	}
}


public CustomTextField Month
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Month"]);
	}
}


#endregion //Field Instance Methods
}
}