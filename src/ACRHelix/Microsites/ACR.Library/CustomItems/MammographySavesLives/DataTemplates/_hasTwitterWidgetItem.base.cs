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
public partial class _hasTwitterWidgetItem : CustomItem
{

public static readonly string TemplateId = "{7DD71678-1153-4B9B-B507-46EE31D0291E}";


#region Boilerplate CustomItem Code

public _hasTwitterWidgetItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasTwitterWidgetItem(Item innerItem)
{
	return innerItem != null ? new _hasTwitterWidgetItem(innerItem) : null;
}

public static implicit operator Item(_hasTwitterWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TwitterWidgetEmbedCode
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Twitter Widget Embed Code"]);
	}
}


public CustomTextField TwitterWidgetTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Twitter Widget Title"]);
	}
}


#endregion //Field Instance Methods
}
}