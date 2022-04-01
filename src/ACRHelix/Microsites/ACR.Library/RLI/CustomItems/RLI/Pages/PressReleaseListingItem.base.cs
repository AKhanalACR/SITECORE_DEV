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
public partial class PressReleaseListingItem : CustomItem
{

public static readonly string TemplateId = "{2E96BF8B-A877-4DC5-B1CE-747B555EF822}";

#region Inherited Base Templates

private readonly NavigationBaseItem _NavigationBaseItem;
public NavigationBaseItem NavigationBase { get { return _NavigationBaseItem; } }
private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }
private readonly BackgroundBaseItem _BackgroundBaseItem;
public BackgroundBaseItem BackgroundBase { get { return _BackgroundBaseItem; } }
private readonly WidgetPageBaseItem _WidgetPageBaseItem;
public WidgetPageBaseItem WidgetPageBase { get { return _WidgetPageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public PressReleaseListingItem(Item innerItem) : base(innerItem)
{
	_NavigationBaseItem = new NavigationBaseItem(innerItem);
	_PageBaseItem = new PageBaseItem(innerItem);
	_BackgroundBaseItem = new BackgroundBaseItem(innerItem);
	_WidgetPageBaseItem = new WidgetPageBaseItem(innerItem);

}

public static implicit operator PressReleaseListingItem(Item innerItem)
{
	return innerItem != null ? new PressReleaseListingItem(innerItem) : null;
}

public static implicit operator Item(PressReleaseListingItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}


#endregion //Field Instance Methods
}
}