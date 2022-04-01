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
public partial class ChapterLandingItem : CustomItem
{

public static readonly string TemplateId = "{58369F24-4D6C-4DAD-B4A9-7401D344B211}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public ChapterLandingItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);

}

public static implicit operator ChapterLandingItem(Item innerItem)
{
	return innerItem != null ? new ChapterLandingItem(innerItem) : null;
}

public static implicit operator Item(ChapterLandingItem customItem)
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


public CustomImageField AboutUsImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["About Us Image"]);
	}
}

public static string FieldName_AboutUsImage 
{
	get
	{
		return "About Us Image";
	}
} 


public CustomTextField AboutUsDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["About Us Description"]);
	}
}

public static string FieldName_AboutUsDescription 
{
	get
	{
		return "About Us Description";
	}
} 


public CustomGeneralLinkField AboutUsLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["About Us Link"]);
	}
}

public static string FieldName_AboutUsLink 
{
	get
	{
		return "About Us Link";
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


public CustomGeneralLinkField JoinUs
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Join Us"]);
	}
}

public static string FieldName_JoinUs 
{
	get
	{
		return "Join Us";
	}
} 


public CustomImageField JoinUsImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Join Us Image"]);
	}
}

public static string FieldName_JoinUsImage 
{
	get
	{
		return "Join Us Image";
	}
} 


public CustomTextField JoinUsDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Join Us Description"]);
	}
}

public static string FieldName_JoinUsDescription 
{
	get
	{
		return "Join Us Description";
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