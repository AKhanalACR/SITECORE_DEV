using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.AIRP.Components
{
public partial class PartnerListItem : CustomItem
{

public static readonly string TemplateId = "{7DC41753-418D-4406-88D6-4F50F69439A0}";


#region Boilerplate CustomItem Code

public PartnerListItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PartnerListItem(Item innerItem)
{
	return innerItem != null ? new PartnerListItem(innerItem) : null;
}

public static implicit operator Item(PartnerListItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}


public CustomImageField Icon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon"]);
	}
}


public CustomTextField Location
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Location"]);
	}
}


public CustomTextField EventDate
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Date"]);
	}
}


public CustomTextField Website
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Website"]);
	}
}


public CustomTextField CourseOrganizers
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Course Organizers"]);
	}
}


#endregion //Field Instance Methods
}
}