using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.Base
{
public partial class VideoContentItem : CustomItem
{

public static readonly string TemplateId = "{458CE0E9-17FC-41D6-BC08-823128D59A09}";


#region Boilerplate CustomItem Code

public VideoContentItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator VideoContentItem(Item innerItem)
{
	return innerItem != null ? new VideoContentItem(innerItem) : null;
}

public static implicit operator Item(VideoContentItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField VideoId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Id"]);
	}
}

public static string FieldName_VideoId 
{
	get
	{
		return "Video Id";
	}
} 


public CustomTextField VideoTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Title"]);
	}
}

public static string FieldName_VideoTitle 
{
	get
	{
		return "Video Title";
	}
} 


public CustomTextField VideoCaption
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video Caption"]);
	}
}

public static string FieldName_VideoCaption 
{
	get
	{
		return "Video Caption";
	}
} 


public CustomIntegerField PlayerWidthOverride
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Player Width Override"]);
	}
}

public static string FieldName_PlayerWidthOverride 
{
	get
	{
		return "Player Width Override";
	}
} 


public CustomIntegerField PlayerHeightOverride
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Player Height Override"]);
	}
}

public static string FieldName_PlayerHeightOverride 
{
	get
	{
		return "Player Height Override";
	}
} 


public CustomCheckboxField IsPlaylist
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Is Playlist"]);
	}
}

public static string FieldName_IsPlaylist 
{
	get
	{
		return "Is Playlist";
	}
} 


#endregion //Field Instance Methods
}
}