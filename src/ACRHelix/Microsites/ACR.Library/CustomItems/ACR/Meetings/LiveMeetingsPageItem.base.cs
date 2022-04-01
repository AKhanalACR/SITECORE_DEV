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

namespace ACR.Library.ACR.Meetings
{
public partial class LiveMeetingsPageItem : CustomItem
{

public static readonly string TemplateId = "{7FA70F2B-6CDF-451C-853A-626EC67CAC36}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public LiveMeetingsPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);

}

public static implicit operator LiveMeetingsPageItem(Item innerItem)
{
	return innerItem != null ? new LiveMeetingsPageItem(innerItem) : null;
}

public static implicit operator Item(LiveMeetingsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField CourseMaterialsImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Course Materials Image"]);
	}
}

public static string FieldName_CourseMaterialsImage 
{
	get
	{
		return "Course Materials Image";
	}
} 


public CustomTreeListField FeaturedMeetingsandCourses
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Meetings and Courses"]);
	}
}

public static string FieldName_FeaturedMeetingsandCourses 
{
	get
	{
		return "Featured Meetings and Courses";
	}
} 


public CustomImageField ParentPageThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Parent Page Thumbnail"]);
	}
}

public static string FieldName_ParentPageThumbnail 
{
	get
	{
		return "Parent Page Thumbnail";
	}
} 


public CustomTextField CourseMaterialsTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Course Materials Title"]);
	}
}

public static string FieldName_CourseMaterialsTitle 
{
	get
	{
		return "Course Materials Title";
	}
} 


public CustomTextField ParentPageIntroText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Parent Page Intro Text"]);
	}
}

public static string FieldName_ParentPageIntroText 
{
	get
	{
		return "Parent Page Intro Text";
	}
} 


public CustomTreeListField UpcomingMeetingsandCourses
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Upcoming Meetings and Courses"]);
	}
}

public static string FieldName_UpcomingMeetingsandCourses 
{
	get
	{
		return "Upcoming Meetings and Courses";
	}
} 


public CustomTextField CourseMaterialsDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Course Materials Description"]);
	}
}

public static string FieldName_CourseMaterialsDescription 
{
	get
	{
		return "Course Materials Description";
	}
} 


public CustomCheckboxField SuppressParentPageFeature
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Suppress Parent Page Feature"]);
	}
}

public static string FieldName_SuppressParentPageFeature 
{
	get
	{
		return "Suppress Parent Page Feature";
	}
} 


public CustomGeneralLinkField CourseMaterialsLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Course Materials Link"]);
	}
}

public static string FieldName_CourseMaterialsLink 
{
	get
	{
		return "Course Materials Link";
	}
} 


#endregion //Field Instance Methods
}
}