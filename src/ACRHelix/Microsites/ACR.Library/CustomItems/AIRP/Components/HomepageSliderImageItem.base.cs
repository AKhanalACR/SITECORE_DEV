using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.AIRP.Components
{
public partial class HomepageSliderImageItem : CustomItem
{

public static readonly string TemplateId = "{FB165BB6-CC7C-42C1-AA12-86492443E260}";


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


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomGeneralLinkField ImageLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Image Link"]);
	}
}


#endregion //Field Instance Methods
}
}