using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Globals
{
public partial class HeaderItem : CustomItem
{

public static readonly string TemplateId = "{723177F2-FA2D-4A7B-8BCF-0AC2D9AA7F51}";


#region Boilerplate CustomItem Code

public HeaderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator HeaderItem(Item innerItem)
{
	return innerItem != null ? new HeaderItem(innerItem) : null;
}

public static implicit operator Item(HeaderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField LogoImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Logo Image"]);
	}
}

public static string FieldName_LogoImage 
{
	get
	{
		return "Logo Image";
	}
} 


public CustomMultiListField SocialLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Social Links"]);
	}
}

public static string FieldName_SocialLinks 
{
	get
	{
		return "Social Links";
	}
} 


public CustomMultiListField HeaderLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Header Links"]);
	}
}

public static string FieldName_HeaderLinks 
{
	get
	{
		return "Header Links";
	}
} 


#endregion //Field Instance Methods
}
}