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
public partial class ChapterLandingLiteItem : CustomItem
{

public static readonly string TemplateId = "{3A7B7B9F-061E-4BF2-885C-14C4E521A23F}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public ChapterLandingLiteItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);

}

public static implicit operator ChapterLandingLiteItem(Item innerItem)
{
	return innerItem != null ? new ChapterLandingLiteItem(innerItem) : null;
}

public static implicit operator Item(ChapterLandingLiteItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField AssociatedProducts
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Associated Products"]);
	}
}

public static string FieldName_AssociatedProducts 
{
	get
	{
		return "Associated Products";
	}
} 


public CustomImageField ChapterHeaderImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Chapter Header Image"]);
	}
}

public static string FieldName_ChapterHeaderImage 
{
	get
	{
		return "Chapter Header Image";
	}
} 


public CustomImageField ContactInformationImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Contact Information Image"]);
	}
}

public static string FieldName_ContactInformationImage 
{
	get
	{
		return "Contact Information Image";
	}
} 


public CustomTextField ContactInformationDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Contact Information Description"]);
	}
}

public static string FieldName_ContactInformationDescription 
{
	get
	{
		return "Contact Information Description";
	}
} 


public CustomGeneralLinkField ContactInformationLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Contact Information Link"]);
	}
}

public static string FieldName_ContactInformationLink 
{
	get
	{
		return "Contact Information Link";
	}
} 


public CustomImageField MembershipImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Membership Image"]);
	}
}

public static string FieldName_MembershipImage 
{
	get
	{
		return "Membership Image";
	}
} 


public CustomTextField MembershipDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Membership Description"]);
	}
}

public static string FieldName_MembershipDescription 
{
	get
	{
		return "Membership Description";
	}
} 


public CustomGeneralLinkField MembershipLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Membership Link"]);
	}
}

public static string FieldName_MembershipLink 
{
	get
	{
		return "Membership Link";
	}
} 


public CustomGeneralLinkField ChapterWebsite
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Chapter Website"]);
	}
}

public static string FieldName_ChapterWebsite 
{
	get
	{
		return "Chapter Website";
	}
} 


public CustomTreeListField ChapterResources
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Chapter Resources"]);
	}
}

public static string FieldName_ChapterResources 
{
	get
	{
		return "Chapter Resources";
	}
} 


public CustomImageField ChapterLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Chapter Logo"]);
	}
}

public static string FieldName_ChapterLogo 
{
	get
	{
		return "Chapter Logo";
	}
} 


#endregion //Field Instance Methods
}
}