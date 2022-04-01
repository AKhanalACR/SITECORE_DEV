using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.MediaCenter
{
public partial class SpokespersonsFolderItem : CustomItem
{

public static readonly string TemplateId = "{60AAB889-8C49-4F88-BE01-C116AB1A3C26}";


#region Boilerplate CustomItem Code

public SpokespersonsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SpokespersonsFolderItem(Item innerItem)
{
	return innerItem != null ? new SpokespersonsFolderItem(innerItem) : null;
}

public static implicit operator Item(SpokespersonsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}