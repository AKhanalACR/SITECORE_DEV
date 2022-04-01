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
public partial class _hasPodcastsItem : CustomItem
{
public static readonly string TemplateId = "{0FBFA8A2-87E6-4C1D-A93E-C0E340993443}";

#region Boilerplate CustomItem Code

public _hasPodcastsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasPodcastsItem(Item innerItem)
{
	return innerItem != null ? new _hasPodcastsItem(innerItem) : null;
}

public static implicit operator Item(_hasPodcastsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField PodcastContent
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Podcast Content"]);
	}
}


public CustomTextField PodcastLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Podcast Label"]);
	}
}


#endregion //Field Instance Methods
}
}