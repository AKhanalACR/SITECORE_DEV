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
public partial class StoriesItem : CustomItem
{
public static readonly string TemplateId = "{99221ED8-EFB7-4A15-88AB-C2CF7C9B444D}";

#region Boilerplate CustomItem Code

public StoriesItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator StoriesItem(Item innerItem)
{
	return innerItem != null ? new StoriesItem(innerItem) : null;
}

public static implicit operator Item(StoriesItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField StoryTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Story Title"]);
	}
}


public CustomTextField StoryTeaser
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Story Teaser"]);
	}
}


public CustomTextField StoryDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Story Description"]);
	}
}


public CustomImageField StoryThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Story Thumbnail"]);
	}
}


public CustomGeneralLinkField StoryMoreLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Story More Link"]);
	}
}


#endregion //Field Instance Methods
}
}