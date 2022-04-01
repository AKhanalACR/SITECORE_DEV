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
public partial class CategoricalCoursePageItem : CustomItem
{

public static readonly string TemplateId = "{2057F56E-5E03-48B9-A5E2-3CCE27672812}";

#region Inherited Base Templates

private readonly InternalPageItem _InternalPageItem;
public InternalPageItem InternalPage { get { return _InternalPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CategoricalCoursePageItem(Item innerItem) : base(innerItem)
{
	_InternalPageItem = new InternalPageItem(innerItem);

}

public static implicit operator CategoricalCoursePageItem(Item innerItem)
{
	return innerItem != null ? new CategoricalCoursePageItem(innerItem) : null;
}

public static implicit operator Item(CategoricalCoursePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Icon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon"]);
	}
}


public CustomDateField StartDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["StartDate"]);
	}
}


public CustomDateField EndDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["EndDate"]);
	}
}


public CustomTextField ManualDate
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["ManualDate"]);
	}
}


#endregion //Field Instance Methods
}
}