using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class NewsReleasessItem : CustomItem
{
public static readonly string TemplateId = "{4EC49B53-5B66-4A66-B427-096F01925224}";
#region Inherited Base Templates

private readonly PromosItem _PromosItem;
public PromosItem Promos { get { return _PromosItem; } }

#endregion

#region Boilerplate CustomItem Code

public NewsReleasessItem(Item innerItem) : base(innerItem)
{
	_PromosItem = new PromosItem(innerItem);

}

public static implicit operator NewsReleasessItem(Item innerItem)
{
	return innerItem != null ? new NewsReleasessItem(innerItem) : null;
}

public static implicit operator Item(NewsReleasessItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}