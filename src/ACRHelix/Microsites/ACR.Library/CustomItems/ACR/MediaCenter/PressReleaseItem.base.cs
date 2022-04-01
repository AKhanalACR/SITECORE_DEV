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

namespace ACR.Library.ACR.MediaCenter
{
public partial class PressReleaseItem : CustomItem
{

public static readonly string TemplateId = "{06F2191A-DB41-465B-9ACA-1DAFD5F3FDFD}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PressReleaseItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator PressReleaseItem(Item innerItem)
{
	return innerItem != null ? new PressReleaseItem(innerItem) : null;
}

public static implicit operator Item(PressReleaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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


public CustomTextField FooterText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Footer Text"]);
	}
}

public static string FieldName_FooterText 
{
	get
	{
		return "Footer Text";
	}
} 


#endregion //Field Instance Methods
}
}