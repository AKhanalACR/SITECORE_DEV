using System;
using ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.PageTemplates
{
public partial class ResearchPageItem : CustomItem
{
public static readonly string TemplateId = "{24B26362-FD6D-4870-B4CB-E6FBEAF566A4}";
#region Inherited Base Templates

private readonly DetailPageItem _DetailPageItem;
public DetailPageItem DetailPage { get { return _DetailPageItem; } }
private readonly _hasResearchItemsItem __hasResearchItemsItem;
public _hasResearchItemsItem hasResearchItems { get { return __hasResearchItemsItem; } }

#endregion

#region Boilerplate CustomItem Code

public ResearchPageItem(Item innerItem) : base(innerItem)
{
	_DetailPageItem = new DetailPageItem(innerItem);
	__hasResearchItemsItem = new _hasResearchItemsItem(innerItem);

}

public static implicit operator ResearchPageItem(Item innerItem)
{
	return innerItem != null ? new ResearchPageItem(innerItem) : null;
}

public static implicit operator Item(ResearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}