using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.CodingSource;

namespace ACR.Library.ACR.CodingSource
{
public partial class CodingSourceWideDetailPageItem : CustomItem
{

public static readonly string TemplateId = "{4A6F89DD-F8F5-40DA-B68D-FC93D6896701}";

#region Inherited Base Templates

private readonly CodingSourceDetailPageItem _CodingSourceDetailPageItem;
public CodingSourceDetailPageItem CodingSourceDetailPage { get { return _CodingSourceDetailPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CodingSourceWideDetailPageItem(Item innerItem) : base(innerItem)
{
	_CodingSourceDetailPageItem = new CodingSourceDetailPageItem(innerItem);

}

public static implicit operator CodingSourceWideDetailPageItem(Item innerItem)
{
	return innerItem != null ? new CodingSourceWideDetailPageItem(innerItem) : null;
}

public static implicit operator Item(CodingSourceWideDetailPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}