using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Membership
{
public partial class ResidentFellowsMeetingItem : CustomItem
{

public static readonly string TemplateId = "{C3DF691A-6869-421F-984C-0087B9C11038}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ResidentFellowsMeetingItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator ResidentFellowsMeetingItem(Item innerItem)
{
	return innerItem != null ? new ResidentFellowsMeetingItem(innerItem) : null;
}

public static implicit operator Item(ResidentFellowsMeetingItem customItem)
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


public CustomDateField StartDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Start Date"]);
	}
}

public static string FieldName_StartDate 
{
	get
	{
		return "Start Date";
	}
} 


public CustomDateField EndDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["End Date"]);
	}
}

public static string FieldName_EndDate 
{
	get
	{
		return "End Date";
	}
} 


public CustomTextField Location
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Location"]);
	}
}

public static string FieldName_Location 
{
	get
	{
		return "Location";
	}
} 


public CustomTextField Venue
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Venue"]);
	}
}

public static string FieldName_Venue 
{
	get
	{
		return "Venue";
	}
} 


public CustomTextField ContactName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Contact Name"]);
	}
}

public static string FieldName_ContactName 
{
	get
	{
		return "Contact Name";
	}
} 


public CustomTextField ContactEmail
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Contact Email"]);
	}
}

public static string FieldName_ContactEmail 
{
	get
	{
		return "Contact Email";
	}
} 


public CustomTextField ContactPhone
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Contact Phone"]);
	}
}

public static string FieldName_ContactPhone 
{
	get
	{
		return "Contact Phone";
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


#endregion //Field Instance Methods
}
}