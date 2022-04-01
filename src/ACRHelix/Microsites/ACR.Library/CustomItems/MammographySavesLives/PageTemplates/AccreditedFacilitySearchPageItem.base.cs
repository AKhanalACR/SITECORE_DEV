using System;
using ACR.Library.MSL.CustomItems.MammographySavesLives.PageTemplates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.MammographySavesLives.PageTemplates;

namespace ACR.Library.MammographySavesLives.PageTemplates
{
public partial class AccreditedFacilitySearchPageItem : CustomItem
{

public static readonly string TemplateId = "{AA745322-0F43-4719-B23B-95F6D38713ED}";

#region Inherited Base Templates

private readonly DetailPageItem _DetailPageItem;
public DetailPageItem DetailPage { get { return _DetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AccreditedFacilitySearchPageItem(Item innerItem) : base(innerItem)
{
	_DetailPageItem = new DetailPageItem(innerItem);

}

public static implicit operator AccreditedFacilitySearchPageItem(Item innerItem)
{
	return innerItem != null ? new AccreditedFacilitySearchPageItem(innerItem) : null;
}

public static implicit operator Item(AccreditedFacilitySearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AdditionalInformation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Additional Information"]);
	}
}


#endregion //Field Instance Methods
}
}