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
public partial class _hasSlidesItem : CustomItem
{
public static readonly string TemplateId = "{6971F44B-A221-4E4B-ABC6-3DF402EF51A6}";

#region Boilerplate CustomItem Code

public _hasSlidesItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasSlidesItem(Item innerItem)
{
	return innerItem != null ? new _hasSlidesItem(innerItem) : null;
}

public static implicit operator Item(_hasSlidesItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField Slides
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Slides"]);
	}
}


public CustomIntegerField SlideshowTransitionSpeed
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Slideshow Transition Speed"]);
	}
}


public CustomIntegerField SlideshowPauseDuration
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Slideshow Pause Duration"]);
	}
}


public CustomIntegerField SlideshowCycles
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Slideshow Cycles"]);
	}
}


#endregion //Field Instance Methods
}
}