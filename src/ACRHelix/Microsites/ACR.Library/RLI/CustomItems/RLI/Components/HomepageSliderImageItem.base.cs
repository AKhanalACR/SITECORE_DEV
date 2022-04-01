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
public partial class HomepageSliderImageItem : CustomItem
{

public static readonly string TemplateId = "{6F02C656-8232-4343-899E-CDF75EA3A2B6}";


#region Boilerplate CustomItem Code

public HomepageSliderImageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator HomepageSliderImageItem(Item innerItem)
{
	return innerItem != null ? new HomepageSliderImageItem(innerItem) : null;
}

public static implicit operator Item(HomepageSliderImageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
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