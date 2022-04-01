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
public partial class ProductStubsFolderItem : CustomItem
{

public static readonly string TemplateId = "{68F942F8-90B5-40D8-A70D-4D09833F2138}";


#region Boilerplate CustomItem Code

public ProductStubsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ProductStubsFolderItem(Item innerItem)
{
	return innerItem != null ? new ProductStubsFolderItem(innerItem) : null;
}

public static implicit operator Item(ProductStubsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}