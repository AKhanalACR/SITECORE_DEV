using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.QualitySafety
{
public partial class AppropriatenessCriteriaSearchPageItem : CustomItem
{

public static readonly string TemplateId = "{66871A95-C618-4D92-A12E-578C11B2076F}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AppropriatenessCriteriaSearchPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);

}

public static implicit operator AppropriatenessCriteriaSearchPageItem(Item innerItem)
{
	return innerItem != null ? new AppropriatenessCriteriaSearchPageItem(innerItem) : null;
}

public static implicit operator Item(AppropriatenessCriteriaSearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}