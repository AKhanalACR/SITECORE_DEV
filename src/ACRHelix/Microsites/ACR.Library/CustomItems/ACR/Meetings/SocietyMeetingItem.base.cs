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

namespace ACR.Library.ACR.Meetings
{
public partial class SocietyMeetingItem : CustomItem
{

public static readonly string TemplateId = "{20B61A16-2B35-40A8-8FDB-B885C1F3F36B}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SocietyMeetingItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator SocietyMeetingItem(Item innerItem)
{
	return innerItem != null ? new SocietyMeetingItem(innerItem) : null;
}

public static implicit operator Item(SocietyMeetingItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField MeetingTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting Title"]);
	}
}

public static string FieldName_MeetingTitle 
{
	get
	{
		return "Meeting Title";
	}
} 


public CustomTextField SocietyName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Society Name"]);
	}
}

public static string FieldName_SocietyName 
{
	get
	{
		return "Society Name";
	}
} 


public CustomDateField MeetingStartDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Meeting Start Date"]);
	}
}

public static string FieldName_MeetingStartDate 
{
	get
	{
		return "Meeting Start Date";
	}
} 


public CustomDateField MeetingEndDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Meeting End Date"]);
	}
}

public static string FieldName_MeetingEndDate 
{
	get
	{
		return "Meeting End Date";
	}
} 


public CustomTextField MeetingLocation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting Location"]);
	}
}

public static string FieldName_MeetingLocation 
{
	get
	{
		return "Meeting Location";
	}
} 


public CustomTextField MeetingVenue
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting Venue"]);
	}
}

public static string FieldName_MeetingVenue 
{
	get
	{
		return "Meeting Venue";
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


public CustomTextField ContactTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Contact Title"]);
	}
}

public static string FieldName_ContactTitle 
{
	get
	{
		return "Contact Title";
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


public CustomTextField ContactAddress
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Contact Address"]);
	}
}

public static string FieldName_ContactAddress 
{
	get
	{
		return "Contact Address";
	}
} 


public CustomGeneralLinkField SiteURL
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Site URL"]);
	}
}

public static string FieldName_SiteURL 
{
	get
	{
		return "Site URL";
	}
} 


#endregion //Field Instance Methods
}
}