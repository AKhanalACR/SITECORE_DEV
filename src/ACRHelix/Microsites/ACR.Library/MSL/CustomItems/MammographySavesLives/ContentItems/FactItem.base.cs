using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class FactItem : CustomItem
{
public static readonly string TemplateId = "{7430C1B5-D0AE-4A95-9BDA-E73DDDB92A9F}";

#region Boilerplate CustomItem Code

public FactItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FactItem(Item innerItem)
{
	return innerItem != null ? new FactItem(innerItem) : null;
}

public static implicit operator Item(FactItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField FactImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Fact Image"]);
	}
}


public CustomTextField FactDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Fact Description"]);
	}
}


#endregion //Field Instance Methods
}
}