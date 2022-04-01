using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI.Components
{
public partial class ButtonItem : CustomItem
{

public static readonly string TemplateId = "{398E1A8E-8A5F-40BE-9505-EDFCA3A64EC2}";


#region Boilerplate CustomItem Code

public ButtonItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ButtonItem(Item innerItem)
{
	return innerItem != null ? new ButtonItem(innerItem) : null;
}

public static implicit operator Item(ButtonItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Icon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


#endregion //Field Instance Methods
}
}