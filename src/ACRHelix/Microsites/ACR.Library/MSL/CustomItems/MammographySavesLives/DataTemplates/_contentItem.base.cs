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
public partial class _contentItem : CustomItem
{
public static readonly string TemplateId = "{B016019E-6D38-4755-B899-7D40F25AC6C0}";

#region Boilerplate CustomItem Code

public _contentItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _contentItem(Item innerItem)
{
	return innerItem != null ? new _contentItem(innerItem) : null;
}

public static implicit operator Item(_contentItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PageTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Page Title"]);
	}
}


public CustomTextField PageDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Page Description"]);
	}
}


public CustomTextField Content
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Content"]);
	}
}


#endregion //Field Instance Methods
}
}