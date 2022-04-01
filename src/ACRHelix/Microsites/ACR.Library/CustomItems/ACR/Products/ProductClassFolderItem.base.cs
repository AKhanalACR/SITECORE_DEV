using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Products
{
public partial class ProductClassFolderItem : CustomItem
{

public static readonly string TemplateId = "{6770A627-3CCE-44F7-ABBF-C1CAEE0ECF20}";


#region Boilerplate CustomItem Code

public ProductClassFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ProductClassFolderItem(Item innerItem)
{
	return innerItem != null ? new ProductClassFolderItem(innerItem) : null;
}

public static implicit operator Item(ProductClassFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}