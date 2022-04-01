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
public partial class UpcomingSocietyMeetingsWidgetItem : CustomItem
{

public static readonly string TemplateId = "{CA59B4B4-61BD-4808-8A89-1F85BD0D2FF6}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public UpcomingSocietyMeetingsWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator UpcomingSocietyMeetingsWidgetItem(Item innerItem)
{
	return innerItem != null ? new UpcomingSocietyMeetingsWidgetItem(innerItem) : null;
}

public static implicit operator Item(UpcomingSocietyMeetingsWidgetItem customItem)
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


#endregion //Field Instance Methods
}
}