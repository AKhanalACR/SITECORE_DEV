using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Taxonomy
{
public partial class TaxonomyFolderItem : CustomItem
{

public static readonly string TemplateId = "{96588098-9C3A-479A-B385-9F220FDD843C}";


#region Boilerplate CustomItem Code

public TaxonomyFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TaxonomyFolderItem(Item innerItem)
{
	return innerItem != null ? new TaxonomyFolderItem(innerItem) : null;
}

public static implicit operator Item(TaxonomyFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}