using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.MediaCenter
{
public partial class ExpertsDirectoryPageItem : CustomItem
{

    public static readonly string TemplateId = "{3BF2BF59-A631-4B92-9D5E-7322DBD176CB}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }

#endregion

#region Boilerplate CustomItem Code

public ExpertsDirectoryPageItem(Item innerItem)
    : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);

}

public static implicit operator ExpertsDirectoryPageItem(Item innerItem)
{
    return innerItem != null ? new ExpertsDirectoryPageItem(innerItem) : null;
}

public static implicit operator Item(ExpertsDirectoryPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}