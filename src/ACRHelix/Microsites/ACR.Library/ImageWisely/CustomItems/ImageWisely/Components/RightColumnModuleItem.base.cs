using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class RightColumnModuleItem : CustomItem
{
public static readonly string TemplateId = "{E9AAFC59-0E14-4DF4-AA12-FE029348122B}";

#region Boilerplate CustomItem Code

public RightColumnModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RightColumnModuleItem(Item innerItem)
{
	return innerItem != null ? new RightColumnModuleItem(innerItem) : null;
}

public static implicit operator Item(RightColumnModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomImageField Thumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Thumbnail"]);
	}
}


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}


#endregion //Field Instance Methods
}
}