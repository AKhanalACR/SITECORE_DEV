using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Content
{
public partial class ResourceLinkItem : CustomItem
{

public static readonly string TemplateId = "{BB84EEE0-FEC4-4B29-8402-60AB7793625B}";


#region Boilerplate CustomItem Code

public ResourceLinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ResourceLinkItem(Item innerItem)
{
	return innerItem != null ? new ResourceLinkItem(innerItem) : null;
}

public static implicit operator Item(ResourceLinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField Resource
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Resource"]);
	}
}

public static string FieldName_Resource 
{
	get
	{
		return "Resource";
	}
} 


public CustomTextField ResourceTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Resource Title"]);
	}
}

public static string FieldName_ResourceTitle 
{
	get
	{
		return "Resource Title";
	}
} 


public CustomImageField ResourceIcon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Resource Icon"]);
	}
}

public static string FieldName_ResourceIcon 
{
	get
	{
		return "Resource Icon";
	}
} 


public CustomTextField ResourceDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Resource Description"]);
	}
}

public static string FieldName_ResourceDescription 
{
	get
	{
		return "Resource Description";
	}
} 


#endregion //Field Instance Methods
}
}