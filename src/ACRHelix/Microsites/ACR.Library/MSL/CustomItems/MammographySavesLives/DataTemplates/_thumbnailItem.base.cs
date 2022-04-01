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
public partial class _thumbnailItem : CustomItem
{
public static readonly string TemplateId = "{DE0B52F9-2C69-4516-8076-8025888CCCF6}";

#region Boilerplate CustomItem Code

public _thumbnailItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _thumbnailItem(Item innerItem)
{
	return innerItem != null ? new _thumbnailItem(innerItem) : null;
}

public static implicit operator Item(_thumbnailItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Thumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Thumbnail"]);
	}
}


#endregion //Field Instance Methods
}
}