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
public partial class FeaturedSectionsFolderItem : CustomItem
{

public static readonly string TemplateId = "{F58BEFE8-D915-4FDE-8F82-AF9ACA4D108C}";


#region Boilerplate CustomItem Code

public FeaturedSectionsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FeaturedSectionsFolderItem(Item innerItem)
{
	return innerItem != null ? new FeaturedSectionsFolderItem(innerItem) : null;
}

public static implicit operator Item(FeaturedSectionsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}