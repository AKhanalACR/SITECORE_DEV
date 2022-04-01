using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class RotatingCarouselImageItem : CustomItem
{

public static readonly string TemplateId = "{D2B385D9-7C99-47A6-A721-B728C00F5B1C}";


#region Boilerplate CustomItem Code

public RotatingCarouselImageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RotatingCarouselImageItem(Item innerItem)
{
	return innerItem != null ? new RotatingCarouselImageItem(innerItem) : null;
}

public static implicit operator Item(RotatingCarouselImageItem customItem)
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


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}

public static string FieldName_Link 
{
	get
	{
		return "Link";
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

public CustomTextField Details
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Details"]);
	}
}

public static string FieldName_Details
{
	get
	{
		return "Details";
	}
}

public CustomTextField ButtonLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Button Label"]);
	}
}

public static string FieldName_ButtonLabel
{
	get
	{
		return "Button Label";
	}
}


#endregion //Field Instance Methods
}
}