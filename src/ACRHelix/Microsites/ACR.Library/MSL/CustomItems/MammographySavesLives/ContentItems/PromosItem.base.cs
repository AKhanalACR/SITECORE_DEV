using System;
using ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class PromosItem : CustomItem
{
public static readonly string TemplateId = "{676199C3-E909-4C14-9392-911D78BE4933}";
#region Inherited Base Templates

private readonly _promoItem __promoItem;
public _promoItem promo { get { return __promoItem; } }

#endregion

#region Boilerplate CustomItem Code

public PromosItem(Item innerItem) : base(innerItem)
{
	__promoItem = new _promoItem(innerItem);

}

public static implicit operator PromosItem(Item innerItem)
{
	return innerItem != null ? new PromosItem(innerItem) : null;
}

public static implicit operator Item(PromosItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}