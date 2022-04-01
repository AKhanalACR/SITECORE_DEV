using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.PageTemplates
{
public partial class LandingPageItem : CustomItem
{
public static readonly string TemplateId = "{58B59F2E-B4D2-457C-B853-4A087BE9AC47}";
#region Inherited Base Templates

private readonly DetailPageItem _DetailPageItem;
public DetailPageItem DetailPage { get { return _DetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public LandingPageItem(Item innerItem) : base(innerItem)
{
	_DetailPageItem = new DetailPageItem(innerItem);

}

public static implicit operator LandingPageItem(Item innerItem)
{
	return innerItem != null ? new LandingPageItem(innerItem) : null;
}

public static implicit operator Item(LandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}