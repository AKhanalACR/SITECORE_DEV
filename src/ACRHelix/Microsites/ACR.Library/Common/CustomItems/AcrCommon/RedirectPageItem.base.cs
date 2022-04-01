using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.AcrCommon
{
public partial class RedirectPageItem : CustomItem
{

public static readonly string TemplateId = "{9AB8C790-35BB-4BD1-B96D-8959012F8004}";


#region Boilerplate CustomItem Code

public RedirectPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RedirectPageItem(Item innerItem)
{
	return innerItem != null ? new RedirectPageItem(innerItem) : null;
}

public static implicit operator Item(RedirectPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField RedirectUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Redirect Url"]);
	}
}

public static string FieldName_RedirectUrl 
{
	get
	{
		return "Redirect Url";
	}
} 


#endregion //Field Instance Methods
}
}