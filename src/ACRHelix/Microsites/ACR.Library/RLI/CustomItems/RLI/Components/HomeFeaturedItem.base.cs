using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI.Components
{
public partial class HomeFeaturedItem : CustomItem
{

public static readonly string TemplateId = "{52F0441F-FC6B-4F2D-BE2D-F304BF8F3A91}";


#region Boilerplate CustomItem Code

public HomeFeaturedItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator HomeFeaturedItem(Item innerItem)
{
	return innerItem != null ? new HomeFeaturedItem(innerItem) : null;
}

public static implicit operator Item(HomeFeaturedItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField ContentItem
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Content Item"]);
	}
}

public static string FieldName_ContentItem 
{
	get
	{
		return "Content Item";
	}
} 


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}

public static string FieldName_Title 
{
	get
	{
		return "Title";
	}
} 


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}

public static string FieldName_Image 
{
	get
	{
		return "Image";
	}
} 


public CustomTextField Subheader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Subheader"]);
	}
}

public static string FieldName_Subheader 
{
	get
	{
		return "Subheader";
	}
} 


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}

public static string FieldName_Body 
{
	get
	{
		return "Body";
	}
} 


public CustomTextField LinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Text"]);
	}
}

public static string FieldName_LinkText 
{
	get
	{
		return "Link Text";
	}
} 


#endregion //Field Instance Methods
}
}