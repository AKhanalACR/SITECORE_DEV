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
public partial class ChapterNewsItem : CustomItem
{

public static readonly string TemplateId = "{1FF02B34-5E0E-4186-9A6A-E05D0B69607C}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ChapterNewsItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator ChapterNewsItem(Item innerItem)
{
	return innerItem != null ? new ChapterNewsItem(innerItem) : null;
}

public static implicit operator Item(ChapterNewsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField AssociatedChapter
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Associated Chapter"]);
	}
}

public static string FieldName_AssociatedChapter 
{
	get
	{
		return "Associated Chapter";
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


public CustomImageField SourceLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Source Logo"]);
	}
}

public static string FieldName_SourceLogo 
{
	get
	{
		return "Source Logo";
	}
} 


public CustomTextField CopyrightStatement
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Copyright Statement"]);
	}
}

public static string FieldName_CopyrightStatement 
{
	get
	{
		return "Copyright Statement";
	}
} 


#endregion //Field Instance Methods
}
}