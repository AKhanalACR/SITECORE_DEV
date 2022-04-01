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
public partial class _hasFeaturedVideosItem : CustomItem
{
public static readonly string TemplateId = "{50C9A450-9AC1-477F-A6D5-8F92B8689617}";

#region Boilerplate CustomItem Code

public _hasFeaturedVideosItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasFeaturedVideosItem(Item innerItem)
{
	return innerItem != null ? new _hasFeaturedVideosItem(innerItem) : null;
}

public static implicit operator Item(_hasFeaturedVideosItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField FeaturedVideo
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Featured Video"]);
	}
}


public CustomMultiListField SecondaryVideos
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Secondary Videos"]);
	}
}


public CustomImageField FeaturedVideosTitleImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Featured Videos Title Image"]);
	}
}


#endregion //Field Instance Methods
}
}