using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Widgets;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Widgets.General
{
public partial class VideoWidgetItem : CustomItem
{

public static readonly string TemplateId = "{F138F81B-7262-4573-9A2C-A16BFDA1893B}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }
private readonly VideoContentItem _VideoContentItem;
public VideoContentItem VideoContent { get { return _VideoContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public VideoWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);
	_VideoContentItem = new VideoContentItem(innerItem);

}

public static implicit operator VideoWidgetItem(Item innerItem)
{
	return innerItem != null ? new VideoWidgetItem(innerItem) : null;
}

public static implicit operator Item(VideoWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}

public static string FieldName_Title 
{
	get
	{
		return "Title";
	}
} 


public CustomImageField VideoThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Video Thumbnail"]);
	}
}

public static string FieldName_VideoThumbnail 
{
	get
	{
		return "Video Thumbnail";
	}
} 


#endregion //Field Instance Methods
}
}