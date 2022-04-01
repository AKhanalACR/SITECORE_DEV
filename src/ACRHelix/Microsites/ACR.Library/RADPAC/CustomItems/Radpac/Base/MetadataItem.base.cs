using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.Radpac.CustomItems.Radpac.Base
{
public partial class MetadataItem : CustomItem
{
    public static readonly string TemplateId = "{5CFB2EE0-4373-4D7B-9439-0B26867E8FC2}";

#region Boilerplate CustomItem Code

public MetadataItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator MetadataItem(Item innerItem)
{
	return innerItem != null ? new MetadataItem(innerItem) : null;
}

public static implicit operator Item(MetadataItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField MetaTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Title"]);
	}
}


public CustomTextField MetaKeywords
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Keywords"]);
	}
}


public CustomTextField MetaDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Description"]);
	}
}


#endregion //Field Instance Methods
}
}