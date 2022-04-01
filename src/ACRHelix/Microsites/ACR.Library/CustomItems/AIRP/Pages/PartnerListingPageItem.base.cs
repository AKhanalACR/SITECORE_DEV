using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.AIRP.Pages;

namespace ACR.Library.AIRP.Pages
{
public partial class PartnerListingPageItem : CustomItem
{

public static readonly string TemplateId = "{68C6F182-31D3-466E-AFF4-B3E9D9A1202E}";

#region Inherited Base Templates

private readonly InternalPageItem _InternalPageItem;
public InternalPageItem InternalPage { get { return _InternalPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PartnerListingPageItem(Item innerItem) : base(innerItem)
{
	_InternalPageItem = new InternalPageItem(innerItem);

}

public static implicit operator PartnerListingPageItem(Item innerItem)
{
	return innerItem != null ? new PartnerListingPageItem(innerItem) : null;
}

public static implicit operator Item(PartnerListingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}