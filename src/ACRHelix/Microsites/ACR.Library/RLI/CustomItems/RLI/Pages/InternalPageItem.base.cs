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
public partial class InternalPageItem : CustomItem
{

public static readonly string TemplateId = "{2830F6CD-8879-4040-B822-A560DD0E01FC}";

#region Inherited Base Templates

private readonly NavigationBaseItem _NavigationBaseItem;
public NavigationBaseItem NavigationBase { get { return _NavigationBaseItem; } }
private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }
private readonly BackgroundBaseItem _BackgroundBaseItem;
public BackgroundBaseItem BackgroundBase { get { return _BackgroundBaseItem; } }
private readonly InternalPageBaseItem _InternalPageBaseItem;
public InternalPageBaseItem InternalPageBase { get { return _InternalPageBaseItem; } }
private readonly WidgetPageBaseItem _WidgetPageBaseItem;
public WidgetPageBaseItem WidgetPageBase { get { return _WidgetPageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public InternalPageItem(Item innerItem) : base(innerItem)
{
	_NavigationBaseItem = new NavigationBaseItem(innerItem);
	_PageBaseItem = new PageBaseItem(innerItem);
	_BackgroundBaseItem = new BackgroundBaseItem(innerItem);
	_InternalPageBaseItem = new InternalPageBaseItem(innerItem);
	_WidgetPageBaseItem = new WidgetPageBaseItem(innerItem);

}

public static implicit operator InternalPageItem(Item innerItem)
{
	return innerItem != null ? new InternalPageItem(innerItem) : null;
}

public static implicit operator Item(InternalPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Subheader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Subheader"]);
	}
}

public static string FieldName_Subheader 
{
	get
	{
		return "Subheader";
	}
} 


#endregion //Field Instance Methods
}
}