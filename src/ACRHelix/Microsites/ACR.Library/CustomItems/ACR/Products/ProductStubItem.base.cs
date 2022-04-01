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

namespace ACR.Library.ACR.Products
{
public partial class ProductStubItem : CustomItem
{

public static readonly string TemplateId = "{62BEEA1D-6B79-4E0C-A98F-E337E321DBBE}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public ProductStubItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);

}

public static implicit operator ProductStubItem(Item innerItem)
{
	return innerItem != null ? new ProductStubItem(innerItem) : null;
}

public static implicit operator Item(ProductStubItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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


public CustomTextField PersonifyID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Personify ID"]);
	}
}

public static string FieldName_PersonifyID 
{
	get
	{
		return "Personify ID";
	}
} 


public CustomLookupField ProductArea
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Product Area"]);
	}
}

public static string FieldName_ProductArea 
{
	get
	{
		return "Product Area";
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


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}

public static string FieldName_Name 
{
	get
	{
		return "Name";
	}
} 


public CustomLookupField ProductClass
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Product Class"]);
	}
}

public static string FieldName_ProductClass 
{
	get
	{
		return "Product Class";
	}
} 


public CustomTextField LongName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Long Name"]);
	}
}

public static string FieldName_LongName 
{
	get
	{
		return "Long Name";
	}
} 


public CustomDateField MeetingLastRegistrationDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Meeting Last Registration Date"]);
	}
}

public static string FieldName_MeetingLastRegistrationDate 
{
	get
	{
		return "Meeting Last Registration Date";
	}
} 


public CustomLookupField ProductType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Product Type"]);
	}
}

public static string FieldName_ProductType 
{
	get
	{
		return "Product Type";
	}
} 


public CustomTextField Keywords
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Keywords"]);
	}
}

public static string FieldName_Keywords 
{
	get
	{
		return "Keywords";
	}
} 


public CustomTextField MeetingFacilityName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting Facility Name"]);
	}
}

public static string FieldName_MeetingFacilityName 
{
	get
	{
		return "Meeting Facility Name";
	}
} 


public CustomTextField Status
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Status"]);
	}
}

public static string FieldName_Status 
{
	get
	{
		return "Status";
	}
} 


public CustomTextField MeetingLabelName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting Label Name"]);
	}
}

public static string FieldName_MeetingLabelName 
{
	get
	{
		return "Meeting Label Name";
	}
} 


public CustomTextField MeetingCity
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting City"]);
	}
}

public static string FieldName_MeetingCity 
{
	get
	{
		return "Meeting City";
	}
} 


public CustomTextField MeetingState
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting State"]);
	}
}

public static string FieldName_MeetingState 
{
	get
	{
		return "Meeting State";
	}
} 


public CustomTextField CMECredit
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["CME Credit"]);
	}
}

public static string FieldName_CMECredit 
{
	get
	{
		return "CME Credit";
	}
} 


public CustomTreeListField RelatedProducts
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Products"]);
	}
}

public static string FieldName_RelatedProducts 
{
	get
	{
		return "Related Products";
	}
} 


public CustomCheckboxField WebDisplay
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Web Display"]);
	}
}

public static string FieldName_WebDisplay 
{
	get
	{
		return "Web Display";
	}
} 


public CustomTextField MeetingRegistrationFormUrl
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meeting Registration Form Url"]);
	}
}

public static string FieldName_MeetingRegistrationFormUrl 
{
	get
	{
		return "Meeting Registration Form Url";
	}
} 


public CustomTreeListField RelatedTopics
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Topics"]);
	}
}

public static string FieldName_RelatedTopics 
{
	get
	{
		return "Related Topics";
	}
} 


public CustomDateField WebDisplayStartDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Web Display Start Date"]);
	}
}

public static string FieldName_WebDisplayStartDate 
{
	get
	{
		return "Web Display Start Date";
	}
} 


public CustomTreeListField DeliveryMethod
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Delivery Method"]);
	}
}

public static string FieldName_DeliveryMethod 
{
	get
	{
		return "Delivery Method";
	}
} 


public CustomDateField WebDisplayEndDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Web Display End Date"]);
	}
}

public static string FieldName_WebDisplayEndDate 
{
	get
	{
		return "Web Display End Date";
	}
} 


public CustomTreeListField ABRCodes
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["ABR Codes"]);
	}
}

public static string FieldName_ABRCodes 
{
	get
	{
		return "ABR Codes";
	}
} 


public CustomDateField DateModified
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Date Modified"]);
	}
}

public static string FieldName_DateModified 
{
	get
	{
		return "Date Modified";
	}
} 


public CustomTextField StockStatus
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Stock Status"]);
	}
}

public static string FieldName_StockStatus 
{
	get
	{
		return "Stock Status";
	}
} 


public CustomTextField ListPrice
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["List Price"]);
	}
}

public static string FieldName_ListPrice 
{
	get
	{
		return "List Price";
	}
} 


public CustomTextField MemberPrice
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Member Price"]);
	}
}

public static string FieldName_MemberPrice 
{
	get
	{
		return "Member Price";
	}
} 


public CustomTextField MITPrice
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["MIT Price"]);
	}
}

public static string FieldName_MITPrice 
{
	get
	{
		return "MIT Price";
	}
}

public CustomTextField TechnologistsPrice
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Technologists Price"]);
	}
}

public static string FieldName_TechPrice
{
	get
	{
		return "Technologists Price";
	}
}


public CustomTextField ImageSmallUrl
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Image Small Url"]);
	}
}

public static string FieldName_ImageSmallUrl 
{
	get
	{
		return "Image Small Url";
	}
} 


public CustomTextField ImageLargeUrl
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Image Large Url"]);
	}
}

public static string FieldName_ImageLargeUrl 
{
	get
	{
		return "Image Large Url";
	}
} 


public CustomTextField ShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Short Description"]);
	}
}

public static string FieldName_ShortDescription 
{
	get
	{
		return "Short Description";
	}
} 


public CustomTextField LongDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Long Description"]);
	}
}

public static string FieldName_LongDescription 
{
	get
	{
		return "Long Description";
	}
} 


public CustomTextField ProductUrl
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Product Url"]);
	}
}

public static string FieldName_ProductUrl 
{
	get
	{
		return "Product Url";
	}
}

public CustomTreeListField CreditTypes
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Credit Types"]);
	}
}

public static string FieldName_CreditTypes
{
	get
	{
		return "Credit Types";
	}
} 

#endregion //Field Instance Methods
}
}