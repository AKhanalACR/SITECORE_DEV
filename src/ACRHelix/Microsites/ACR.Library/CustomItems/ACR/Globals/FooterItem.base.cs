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
public partial class FooterItem : CustomItem
{

public static readonly string TemplateId = "{C911BCC6-17C1-4B58-8AE7-81016CCABAB9}";


#region Boilerplate CustomItem Code

public FooterItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FooterItem(Item innerItem)
{
	return innerItem != null ? new FooterItem(innerItem) : null;
}

public static implicit operator Item(FooterItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ContactInformation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Contact Information"]);
	}
}

public static string FieldName_ContactInformation 
{
	get
	{
		return "Contact Information";
	}
} 


public CustomTextField CopyrightStatement
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Copyright Statement"]);
	}
}

public static string FieldName_CopyrightStatement 
{
	get
	{
		return "Copyright Statement";
	}
} 


public CustomTextField PhoneNumber
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Phone Number"]);
	}
}

public static string FieldName_PhoneNumber 
{
	get
	{
		return "Phone Number";
	}
} 


public CustomMultiListField FooterOrder
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Footer Order"]);
	}
}

public static string FieldName_FooterOrder 
{
	get
	{
		return "Footer Order";
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


public CustomMultiListField FooterTrailingLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Footer Trailing Links"]);
	}
}

public static string FieldName_FooterTrailingLinks 
{
	get
	{
		return "Footer Trailing Links";
	}
} 


#endregion //Field Instance Methods
}
}