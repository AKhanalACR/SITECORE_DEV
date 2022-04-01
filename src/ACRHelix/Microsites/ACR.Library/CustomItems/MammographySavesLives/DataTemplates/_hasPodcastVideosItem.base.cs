using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MammographySavesLives.DataTemplates
{
public partial class _hasPodcastVideosItem : CustomItem
{

public static readonly string TemplateId = "{57576B18-E7E7-474D-AC5F-F978E36F1C27}";


#region Boilerplate CustomItem Code

public _hasPodcastVideosItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasPodcastVideosItem(Item innerItem)
{
	return innerItem != null ? new _hasPodcastVideosItem(innerItem) : null;
}

public static implicit operator Item(_hasPodcastVideosItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PodcastVideosTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Podcast Videos Title"]);
	}
}


public CustomTextField PodcastVideosIntro
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Podcast Videos Intro"]);
	}
}


public CustomMultiListField PodcastVideos
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Podcast Videos"]);
	}
}


#endregion //Field Instance Methods
}
}