using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Pages
{
public partial class ReportPageItem : CustomItem
{

public static readonly string TemplateId = "{3CAAD9BB-8D32-4E00-9359-6CC3C6E6407D}";

#region Inherited Base Templates

private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }
private readonly FormPageItem _FormPageItem;
public FormPageItem FormPage { get { return _FormPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ReportPageItem(Item innerItem) : base(innerItem)
{
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_BasePageItem = new BasePageItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);
	_FormPageItem = new FormPageItem(innerItem);

}

public static implicit operator ReportPageItem(Item innerItem)
{
	return innerItem != null ? new ReportPageItem(innerItem) : null;
}

public static implicit operator Item(ReportPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}