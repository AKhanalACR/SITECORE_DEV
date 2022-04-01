using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Pages;

namespace ACR.Library.ACR.Membership
{
public partial class MembershipDirectorySearchPageItem : CustomItem
{

public static readonly string TemplateId = "{CCA995DF-F084-473D-8335-425951F17F36}";

#region Inherited Base Templates

private readonly WideBodyPageItem _WideBodyPageItem;
public WideBodyPageItem WideBodyPage { get { return _WideBodyPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public MembershipDirectorySearchPageItem(Item innerItem) : base(innerItem)
{
	_WideBodyPageItem = new WideBodyPageItem(innerItem);

}

public static implicit operator MembershipDirectorySearchPageItem(Item innerItem)
{
	return innerItem != null ? new MembershipDirectorySearchPageItem(innerItem) : null;
}

public static implicit operator Item(MembershipDirectorySearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}