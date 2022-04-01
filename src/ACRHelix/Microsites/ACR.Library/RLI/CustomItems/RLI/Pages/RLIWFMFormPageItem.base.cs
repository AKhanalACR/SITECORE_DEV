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
public partial class RLIWFMFormPageItem : CustomItem
{

public static readonly string TemplateId = "{77CCA038-B7F9-48E4-9032-98C284D87239}";

#region Inherited Base Templates

private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RLIWFMFormPageItem(Item innerItem) : base(innerItem)
{
	_PageBaseItem = new PageBaseItem(innerItem);

}

public static implicit operator RLIWFMFormPageItem(Item innerItem)
{
	return innerItem != null ? new RLIWFMFormPageItem(innerItem) : null;
}

public static implicit operator Item(RLIWFMFormPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}