using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.News.ACR.News
{
public partial class NewsFolderItem : CustomItem
{

public static readonly string TemplateId = "{CC6EC525-CFFD-474B-B7DF-CD365BBCF5E2}";


#region Boilerplate CustomItem Code

public NewsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator NewsFolderItem(Item innerItem)
{
	return innerItem != null ? new NewsFolderItem(innerItem) : null;
}

public static implicit operator Item(NewsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}