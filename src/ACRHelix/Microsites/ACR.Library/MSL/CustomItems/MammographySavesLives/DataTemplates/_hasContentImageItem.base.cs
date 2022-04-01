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
public partial class _hasContentImageItem : CustomItem
{
public static readonly string TemplateId = "{805B49AE-32AD-414F-B6B0-94BD740ECFC1}";

#region Boilerplate CustomItem Code

public _hasContentImageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasContentImageItem(Item innerItem)
{
	return innerItem != null ? new _hasContentImageItem(innerItem) : null;
}

public static implicit operator Item(_hasContentImageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField LeadContentImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Lead Content Image"]);
	}
}


#endregion //Field Instance Methods
}
}