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
public partial class RightColumnModuleItem : CustomItem
{
    public static readonly string TemplateId = "{88083429-9EA3-4531-95F9-ACAAB26BCF32}";

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


public CustomGeneralLinkField ThumbnailURL
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["ThumbnailURL"]);
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