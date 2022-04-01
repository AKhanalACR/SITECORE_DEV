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
using ACR.Library.ACR.Meetings;

namespace ACR.Library.ACR.Meetings
{
public partial class CourseMeetingSummaryItem : CustomItem
{

public static readonly string TemplateId = "{CE60D321-C3BF-4A4F-BFEE-142199E12C94}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly EducationCenterFeatureItem _EducationCenterFeatureItem;
public EducationCenterFeatureItem EducationCenterFeature { get { return _EducationCenterFeatureItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }

#endregion

#region Boilerplate CustomItem Code

public CourseMeetingSummaryItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_EducationCenterFeatureItem = new EducationCenterFeatureItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);

}

public static implicit operator CourseMeetingSummaryItem(Item innerItem)
{
	return innerItem != null ? new CourseMeetingSummaryItem(innerItem) : null;
}

public static implicit operator Item(CourseMeetingSummaryItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField FeatureThumbnailImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Feature Thumbnail Image"]);
	}
}

public static string FieldName_FeatureThumbnailImage 
{
	get
	{
		return "Feature Thumbnail Image";
	}
} 

public CustomTextField HotelName1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hotel Name 1"]);
	}
}
public static string FieldName_HotelName1 
{
	get
	{
		return "Hotel Name 1";
	}
}


public CustomTextField MeetingType
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting Type"]);
	}
}

public static string FieldName_MeetingType 
{
	get
	{
		return "Meeting Type";
	}
} 

public CustomTextField FeatureShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Feature Short Description"]);
	}
}
public static string FieldName_FeatureShortDescription 
{
	get
	{
		return "Feature Short Description";
	}
}


public CustomTextField HotelLocation1
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hotel Location 1"]);
	}
}

public static string FieldName_HotelLocation1 
{
	get
	{
		return "Hotel Location 1";
	}
} 

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


public CustomGeneralLinkField HotelBooking1
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Hotel Booking 1"]);
	}
}

public static string FieldName_HotelBooking1 
{
	get
	{
		return "Hotel Booking 1";
	}
} 

public CustomTextField Overview
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Overview"]);
	}
}
public static string FieldName_Overview 
{
	get
	{
		return "Overview";
	}
}


public CustomGeneralLinkField Brochure
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Brochure"]);
	}
}

public static string FieldName_Brochure 
{
	get
	{
		return "Brochure";
	}
} 

public CustomTextField HotelName2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hotel Name 2"]);
	}
}
public static string FieldName_HotelName2 
{
	get
	{
		return "Hotel Name 2";
	}
}


public CustomTextField HotelLocation2
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hotel Location 2"]);
	}
}

public static string FieldName_HotelLocation2 
{
	get
	{
		return "Hotel Location 2";
	}
} 

public CustomTextField ProgramsandObjectives
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Programs and Objectives"]);
	}
}
public static string FieldName_ProgramsandObjectives 
{
	get
	{
		return "Programs and Objectives";
	}
}


public CustomGeneralLinkField HotelBooking2
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Hotel Booking 2"]);
	}
}

public static string FieldName_HotelBooking2 
{
	get
	{
		return "Hotel Booking 2";
	}
} 

public CustomTreeListField Products
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Products"]);
	}
}
public static string FieldName_Products 
{
	get
	{
		return "Products";
	}
}


public CustomTextField HotelName3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hotel Name 3"]);
	}
}

public static string FieldName_HotelName3 
{
	get
	{
		return "Hotel Name 3";
	}
} 

public CustomTextField Testimonials
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Testimonials"]);
	}
}
public static string FieldName_Testimonials 
{
	get
	{
		return "Testimonials";
	}
}


public CustomTextField HotelLocation3
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Hotel Location 3"]);
	}
}

public static string FieldName_HotelLocation3 
{
	get
	{
		return "Hotel Location 3";
	}
} 

public CustomTextField RegistrationInformation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Registration Information"]);
	}
}
public static string FieldName_RegistrationInformation 
{
	get
	{
		return "Registration Information";
	}
}


public CustomGeneralLinkField HotelBooking3
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Hotel Booking 3"]);
	}
}

public static string FieldName_HotelBooking3 
{
	get
	{
		return "Hotel Booking 3";
	}
} 

public CustomTextField AdditionalInformation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Additional Information"]);
	}
}

public static string FieldName_AdditionalInformation 
{
	get
	{
		return "Additional Information";
	}
} 

#endregion //Field Instance Methods
}
}