using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.AIRP.Pages;

namespace ACR.Library.AIRP.Pages
{
public partial class CategoricalCourseListingPageItem : CustomItem
{

public static readonly string TemplateId = "{D98F709E-7700-4023-B474-2692F8ACE5E2}";

#region Inherited Base Templates

private readonly InternalPageItem _InternalPageItem;
public InternalPageItem InternalPage { get { return _InternalPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CategoricalCourseListingPageItem(Item innerItem) : base(innerItem)
{
	_InternalPageItem = new InternalPageItem(innerItem);

}

public static implicit operator CategoricalCourseListingPageItem(Item innerItem)
{
	return innerItem != null ? new CategoricalCourseListingPageItem(innerItem) : null;
}

public static implicit operator Item(CategoricalCourseListingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}