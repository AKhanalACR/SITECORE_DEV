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

namespace ACR.Library.ACR.Widgets.Personify
{
public partial class FeaturedUpcomingCourseWidgetItem : CustomItem
{

public static readonly string TemplateId = "{FB00C52E-6517-4EA5-8609-11E2FA434497}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public FeaturedUpcomingCourseWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator FeaturedUpcomingCourseWidgetItem(Item innerItem)
{
	return innerItem != null ? new FeaturedUpcomingCourseWidgetItem(innerItem) : null;
}

public static implicit operator Item(FeaturedUpcomingCourseWidgetItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField HeaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Text"]);
	}
}

public static string FieldName_HeaderText 
{
	get
	{
		return "Header Text";
	}
} 


public CustomDateField Date
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Date"]);
	}
}

public static string FieldName_Date 
{
	get
	{
		return "Date";
	}
} 


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


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}

public static string FieldName_Image 
{
	get
	{
		return "Image";
	}
} 


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}

public static string FieldName_Description 
{
	get
	{
		return "Description";
	}
} 


public CustomGeneralLinkField DetailsLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Details Link"]);
	}
}

public static string FieldName_DetailsLink 
{
	get
	{
		return "Details Link";
	}
} 


#endregion //Field Instance Methods
}
}