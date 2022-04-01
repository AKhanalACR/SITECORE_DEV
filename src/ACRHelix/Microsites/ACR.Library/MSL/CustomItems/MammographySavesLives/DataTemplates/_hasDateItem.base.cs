using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates
{
public partial class _hasDateItem : CustomItem
{
public static readonly string TemplateId = "{45451703-7686-4FD9-9055-89FF22A1DB67}";

#region Boilerplate CustomItem Code

public _hasDateItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasDateItem(Item innerItem)
{
	return innerItem != null ? new _hasDateItem(innerItem) : null;
}

public static implicit operator Item(_hasDateItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomDateField PublishDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Publish Date"]);
	}
}


#endregion //Field Instance Methods
}
}