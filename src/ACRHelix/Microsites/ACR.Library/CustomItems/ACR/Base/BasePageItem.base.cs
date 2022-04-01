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

namespace ACR.Library.ACR.Base
{
public partial class BasePageItem : CustomItem
{

public static readonly string TemplateId = "{AC0393AC-5CA1-4AAE-AE04-10FAAFB8E5F4}";

#region Inherited Base Templates

private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }

#endregion

#region Boilerplate CustomItem Code

public BasePageItem(Item innerItem) : base(innerItem)
{
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);

}

public static implicit operator BasePageItem(Item innerItem)
{
	return innerItem != null ? new BasePageItem(innerItem) : null;
}

public static implicit operator Item(BasePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField HideTextSizeOption
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Hide Text Size Option"]);
	}
}

public static string FieldName_HideTextSizeOption 
{
	get
	{
		return "Hide Text Size Option";
	}
} 


public CustomTextField MetaKeywords
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Keywords"]);
	}
}

public static string FieldName_MetaKeywords 
{
	get
	{
		return "Meta Keywords";
	}
} 


public CustomTextField PageTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Page Title"]);
	}
}

public static string FieldName_PageTitle 
{
	get
	{
		return "Page Title";
	}
} 


public CustomCheckboxField RequiresACRMembership
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Requires ACR Membership"]);
	}
}

public static string FieldName_RequiresACRMembership 
{
	get
	{
		return "Requires ACR Membership";
	}
} 


public CustomCheckboxField HideToolbar
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Hide Toolbar"]);
	}
}

public static string FieldName_HideToolbar 
{
	get
	{
		return "Hide Toolbar";
	}
} 


public CustomTextField MetaDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Description"]);
	}
}

public static string FieldName_MetaDescription 
{
	get
	{
		return "Meta Description";
	}
} 


public CustomTreeListField RequiredProducts
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Required Products"]);
	}
}

public static string FieldName_RequiredProducts 
{
	get
	{
		return "Required Products";
	}
} 


public CustomTextField ShortTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Short Title"]);
	}
}

public static string FieldName_ShortTitle 
{
	get
	{
		return "Short Title";
	}
} 


public CustomTextField HeaderTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header Title"]);
	}
}

public static string FieldName_HeaderTitle 
{
	get
	{
		return "Header Title";
	}
} 


public CustomTreeListField RequiredRoles
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Required Roles"]);
	}
}

public static string FieldName_RequiredRoles 
{
	get
	{
		return "Required Roles";
	}
} 


public CustomTextField BodyText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body Text"]);
	}
}

public static string FieldName_BodyText 
{
	get
	{
		return "Body Text";
	}
} 


#endregion //Field Instance Methods
}
}