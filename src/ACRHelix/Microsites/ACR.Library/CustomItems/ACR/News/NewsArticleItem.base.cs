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

namespace ACR.Library.ACR.News
{
public partial class NewsArticleItem : CustomItem
{

public static readonly string TemplateId = "{F0FC6BDB-6F13-45DE-A55D-7EF396139041}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public NewsArticleItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator NewsArticleItem(Item innerItem)
{
	return innerItem != null ? new NewsArticleItem(innerItem) : null;
}

public static implicit operator Item(NewsArticleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField ArticleType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Article Type"]);
	}
}

public static string FieldName_ArticleType 
{
	get
	{
		return "Article Type";
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