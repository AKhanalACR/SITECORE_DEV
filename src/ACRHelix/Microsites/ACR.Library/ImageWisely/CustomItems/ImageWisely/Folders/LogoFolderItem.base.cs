using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Folders
{
public partial class LogoFolderItem : CustomItem
{

public static readonly string TemplateId = "{FE7758DD-4614-4D47-AA85-A3C468203777}";


#region Boilerplate CustomItem Code

public LogoFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator LogoFolderItem(Item innerItem)
{
	return innerItem != null ? new LogoFolderItem(innerItem) : null;
}

public static implicit operator Item(LogoFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}