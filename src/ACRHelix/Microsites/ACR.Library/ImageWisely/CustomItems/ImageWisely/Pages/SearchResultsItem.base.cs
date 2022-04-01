using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
public partial class SearchResultsItem : CustomItem
{
public static readonly string TemplateId = "{201E391B-7598-4C9B-B27D-3879FF4798EB}";
#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }

#endregion

#region Boilerplate CustomItem Code

public SearchResultsItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);

}

public static implicit operator SearchResultsItem(Item innerItem)
{
	return innerItem != null ? new SearchResultsItem(innerItem) : null;
}

public static implicit operator Item(SearchResultsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}