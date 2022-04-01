using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Education
{
public partial class EducationCenterPageItem : CustomItem
{

public static readonly string TemplateId = "{A867CC60-9450-468D-9728-31D66CDD55B0}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public EducationCenterPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);

}

public static implicit operator EducationCenterPageItem(Item innerItem)
{
	return innerItem != null ? new EducationCenterPageItem(innerItem) : null;
}

public static implicit operator Item(EducationCenterPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FeaturedCoursesTitleOverride
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Courses Title Override"]);
	}
}


public CustomTreeListField FeaturedCourses
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Courses"]);
	}
}


public CustomImageField ParentPageThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Parent Page Thumbnail"]);
	}
}


public CustomTextField AboutEductionCenterTitleOverride
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["About Eduction Center Title Override"]);
	}
}


public CustomTreeListField AboutEducationCenterCourses
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["About Education Center Courses"]);
	}
}


public CustomTextField UpcomingCoursesTitleOverride
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Upcoming Courses Title Override"]);
	}
}


public CustomTextField ParentPageIntroText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Parent Page Intro Text"]);
	}
}


public CustomTreeListField UpcomingCourses
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Upcoming Courses"]);
	}
}


public CustomCheckboxField SuppressParentPageFeature
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Suppress Parent Page Feature"]);
	}
}


#endregion //Field Instance Methods
}
}