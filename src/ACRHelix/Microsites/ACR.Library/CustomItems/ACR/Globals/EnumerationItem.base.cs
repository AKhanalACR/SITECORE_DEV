using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.Globals
{
public partial class EnumerationItem : CustomItem
{

public static readonly string TemplateId = "{90409BB5-852C-4EFE-B46F-34EE70DEAC2C}";


#region Boilerplate CustomItem Code

public EnumerationItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EnumerationItem(Item innerItem)
{
	return innerItem != null ? new EnumerationItem(innerItem) : null;
}

public static implicit operator Item(EnumerationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}