using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Folders
{
public partial class TaskForceFolderItem : CustomItem
{
public static readonly string TemplateId = "{0A9DC908-B893-43BC-9110-0FD1E0B5BFB8}";

#region Boilerplate CustomItem Code

public TaskForceFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TaskForceFolderItem(Item innerItem)
{
	return innerItem != null ? new TaskForceFolderItem(innerItem) : null;
}

public static implicit operator Item(TaskForceFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FolderName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Folder Name"]);
	}
}


#endregion //Field Instance Methods
}
}