using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Pages
{
public partial class SearchResultsPageItem : CustomItem
{

public static readonly string TemplateId = "{852E2140-6B5F-4E41-B6AB-82A3B4C5C650}";

#region Inherited Base Templates

private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }
private readonly BackgroundBaseItem _BackgroundBaseItem;
public BackgroundBaseItem BackgroundBase { get { return _BackgroundBaseItem; } }
private readonly WidgetPageBaseItem _WidgetPageBaseItem;
public WidgetPageBaseItem WidgetPageBase { get { return _WidgetPageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public SearchResultsPageItem(Item innerItem) : base(innerItem)
{
	_PageBaseItem = new PageBaseItem(innerItem);
	_BackgroundBaseItem = new BackgroundBaseItem(innerItem);
	_WidgetPageBaseItem = new WidgetPageBaseItem(innerItem);

}

public static implicit operator SearchResultsPageItem(Item innerItem)
{
	return innerItem != null ? new SearchResultsPageItem(innerItem) : null;
}

public static implicit operator Item(SearchResultsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}