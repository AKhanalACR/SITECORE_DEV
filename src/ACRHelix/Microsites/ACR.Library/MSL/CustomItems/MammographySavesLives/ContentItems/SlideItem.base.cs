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
public partial class SlideItem : CustomItem
{
public static readonly string TemplateId = "{CDD9CA69-225E-41F7-89C2-2714F2ABFDE7}";
#region Inherited Base Templates

private readonly _promoItem __promoItem;
public _promoItem promo { get { return __promoItem; } }

#endregion

#region Boilerplate CustomItem Code

public SlideItem(Item innerItem) : base(innerItem)
{
	__promoItem = new _promoItem(innerItem);

}

public static implicit operator SlideItem(Item innerItem)
{
	return innerItem != null ? new SlideItem(innerItem) : null;
}

public static implicit operator Item(SlideItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}