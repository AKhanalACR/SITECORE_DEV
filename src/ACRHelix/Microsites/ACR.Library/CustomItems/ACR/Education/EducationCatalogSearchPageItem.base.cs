using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Education
{
public partial class EducationCatalogSearchPageItem : CustomItem
{

public static readonly string TemplateId = "{30AB0C3D-EC09-403D-AC06-9AB5C27CD6A4}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public EducationCatalogSearchPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);

}

public static implicit operator EducationCatalogSearchPageItem(Item innerItem)
{
	return innerItem != null ? new EducationCatalogSearchPageItem(innerItem) : null;
}

public static implicit operator Item(EducationCatalogSearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}