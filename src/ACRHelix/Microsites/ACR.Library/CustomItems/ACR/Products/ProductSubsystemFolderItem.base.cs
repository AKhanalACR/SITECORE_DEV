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
public partial class ProductSubsystemFolderItem : CustomItem
{

public static readonly string TemplateId = "{124A9B41-6045-4007-AB87-29E5DAB8F9D3}";


#region Boilerplate CustomItem Code

public ProductSubsystemFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ProductSubsystemFolderItem(Item innerItem)
{
	return innerItem != null ? new ProductSubsystemFolderItem(innerItem) : null;
}

public static implicit operator Item(ProductSubsystemFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}