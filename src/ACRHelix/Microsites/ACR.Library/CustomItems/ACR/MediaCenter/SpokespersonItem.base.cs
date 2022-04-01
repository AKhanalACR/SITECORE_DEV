using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.MediaCenter
{
public partial class SpokespersonItem : CustomItem
{

public static readonly string TemplateId = "{87C8B7E9-81A7-402C-81B5-191B40AAEB2B}";

#region Inherited Base Templates

private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public SpokespersonItem(Item innerItem) : base(innerItem)
{
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator SpokespersonItem(Item innerItem)
{
	return innerItem != null ? new SpokespersonItem(innerItem) : null;
}

public static implicit operator Item(SpokespersonItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}

public static string FieldName_Name 
{
	get
	{
		return "Name";
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


public CustomTextField Credentials
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Credentials"]);
	}
}

public static string FieldName_Credentials 
{
	get
	{
		return "Credentials";
	}
} 


public CustomTextField Position
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Position"]);
	}
}

public static string FieldName_Position 
{
	get
	{
		return "Position";
	}
} 


public CustomTextField Location
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Location"]);
	}
}

public static string FieldName_Location 
{
	get
	{
		return "Location";
	}
} 


public CustomTextField Biography
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Biography"]);
	}
}

public static string FieldName_Biography 
{
	get
	{
		return "Biography";
	}
} 


public CustomCheckboxField FeaturedSpokesperson
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Featured Spokesperson"]);
	}
}

public static string FieldName_FeaturedSpokesperson 
{
	get
	{
		return "Featured Spokesperson";
	}
} 


#endregion //Field Instance Methods
}
}