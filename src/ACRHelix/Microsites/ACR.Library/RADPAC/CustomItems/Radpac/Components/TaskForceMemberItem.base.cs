using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.Radpac.CustomItems.Radpac.Components
{
public partial class TaskForceMemberItem : CustomItem
{
    public static readonly string TemplateId = "{6A303F69-64E2-4C9D-9E4A-8B86329C789B}";

#region Boilerplate CustomItem Code

public TaskForceMemberItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TaskForceMemberItem(Item innerItem)
{
	return innerItem != null ? new TaskForceMemberItem(innerItem) : null;
}

public static implicit operator Item(TaskForceMemberItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FirstName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["First Name"]);
	}
}


public CustomTextField LastName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Last Name"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


#endregion //Field Instance Methods
}
}