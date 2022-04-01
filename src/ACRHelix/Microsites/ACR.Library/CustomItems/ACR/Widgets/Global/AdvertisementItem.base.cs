using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Widgets.Global
{
public partial class AdvertisementItem : CustomItem
{

public static readonly string TemplateId = "{C8ED7FC0-6585-4AF3-86C9-78263645AFA5}";


#region Boilerplate CustomItem Code

public AdvertisementItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AdvertisementItem(Item innerItem)
{
	return innerItem != null ? new AdvertisementItem(innerItem) : null;
}

public static implicit operator Item(AdvertisementItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AdvertisementJavascript
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Advertisement Javascript"]);
	}
}


#endregion //Field Instance Methods
}
}