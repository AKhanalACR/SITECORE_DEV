using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Home
{
public partial class FeaturedContentFolderItem : CustomItem
{

public static readonly string TemplateId = "{A5170C65-A6E3-42B2-818B-795A50A72AA6}";


#region Boilerplate CustomItem Code

public FeaturedContentFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FeaturedContentFolderItem(Item innerItem)
{
	return innerItem != null ? new FeaturedContentFolderItem(innerItem) : null;
}

public static implicit operator Item(FeaturedContentFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}