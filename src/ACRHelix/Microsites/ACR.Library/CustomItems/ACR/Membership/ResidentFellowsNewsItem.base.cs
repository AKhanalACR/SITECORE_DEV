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
public partial class ResidentFellowsNewsItem : CustomItem
{

public static readonly string TemplateId = "{3ADED934-FCC0-473A-8B7F-F5BD23CD04A7}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ResidentFellowsNewsItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator ResidentFellowsNewsItem(Item innerItem)
{
	return innerItem != null ? new ResidentFellowsNewsItem(innerItem) : null;
}

public static implicit operator Item(ResidentFellowsNewsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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


public CustomTextField Subtitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Subtitle"]);
	}
}

public static string FieldName_Subtitle 
{
	get
	{
		return "Subtitle";
	}
} 


public CustomTextField Author
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Author"]);
	}
}

public static string FieldName_Author 
{
	get
	{
		return "Author";
	}
} 


public CustomTextField BodyText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body Text"]);
	}
}

public static string FieldName_BodyText 
{
	get
	{
		return "Body Text";
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