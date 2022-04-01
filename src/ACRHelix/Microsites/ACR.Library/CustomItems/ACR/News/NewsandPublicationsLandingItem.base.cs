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
public partial class NewsandPublicationsLandingItem : CustomItem
{

public static readonly string TemplateId = "{855F6B53-5933-42D6-ABB6-E3EE09DCEF98}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public NewsandPublicationsLandingItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);

}

public static implicit operator NewsandPublicationsLandingItem(Item innerItem)
{
	return innerItem != null ? new NewsandPublicationsLandingItem(innerItem) : null;
}

public static implicit operator Item(NewsandPublicationsLandingItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField FeaturedArticle
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Featured Article"]);
	}
}

public static string FieldName_FeaturedArticle 
{
	get
	{
		return "Featured Article";
	}
} 


public CustomImageField JACRImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["JACR Image"]);
	}
}

public static string FieldName_JACRImage 
{
	get
	{
		return "JACR Image";
	}
} 


public CustomGeneralLinkField JACRImageLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["JACR Image Link"]);
	}
}

public static string FieldName_JACRImageLink 
{
	get
	{
		return "JACR Image Link";
	}
} 


public CustomTextField JACRDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["JACR Description"]);
	}
}

public static string FieldName_JACRDescription 
{
	get
	{
		return "JACR Description";
	}
} 


public CustomTextField PublicationTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Publication Title"]);
	}
}

public static string FieldName_PublicationTitle 
{
	get
	{
		return "Publication Title";
	}
} 


public CustomImageField ACRBulletinImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["ACR Bulletin Image"]);
	}
}

public static string FieldName_ACRBulletinImage 
{
	get
	{
		return "ACR Bulletin Image";
	}
} 


public CustomDateField PublicationDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Publication Date"]);
	}
}

public static string FieldName_PublicationDate 
{
	get
	{
		return "Publication Date";
	}
} 


public CustomGeneralLinkField ACRImageLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["ACR Image Link"]);
	}
}

public static string FieldName_ACRImageLink 
{
	get
	{
		return "ACR Image Link";
	}
} 


public CustomTextField ACRDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ACR Description"]);
	}
}

public static string FieldName_ACRDescription 
{
	get
	{
		return "ACR Description";
	}
} 


public CustomTextField PublicationDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Publication Description"]);
	}
}

public static string FieldName_PublicationDescription 
{
	get
	{
		return "Publication Description";
	}
} 


public CustomImageField PublicationImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Publication Image"]);
	}
}

public static string FieldName_PublicationImage 
{
	get
	{
		return "Publication Image";
	}
} 


public CustomGeneralLinkField PublicationLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Publication Link"]);
	}
}

public static string FieldName_PublicationLink 
{
	get
	{
		return "Publication Link";
	}
} 


#endregion //Field Instance Methods
}
}