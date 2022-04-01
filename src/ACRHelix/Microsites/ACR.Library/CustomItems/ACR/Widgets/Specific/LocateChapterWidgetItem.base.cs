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

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class LocateChapterWidgetItem : CustomItem
{

public static readonly string TemplateId = "{EB135AC7-E5C0-47CD-A938-9F7BE14AE794}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public LocateChapterWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator LocateChapterWidgetItem(Item innerItem)
{
	return innerItem != null ? new LocateChapterWidgetItem(innerItem) : null;
}

public static implicit operator Item(LocateChapterWidgetItem customItem)
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


public CustomTextField Text
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Text"]);
	}
}

public static string FieldName_Text 
{
	get
	{
		return "Text";
	}
} 


public CustomGeneralLinkField ChapterServicesLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Chapter Services Link"]);
	}
}

public static string FieldName_ChapterServicesLink 
{
	get
	{
		return "Chapter Services Link";
	}
} 


public CustomGeneralLinkField ChapterMeetingsandEventsLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Chapter Meetings and Events Link"]);
	}
}

public static string FieldName_ChapterMeetingsandEventsLink 
{
	get
	{
		return "Chapter Meetings and Events Link";
	}
} 


#endregion //Field Instance Methods
}
}