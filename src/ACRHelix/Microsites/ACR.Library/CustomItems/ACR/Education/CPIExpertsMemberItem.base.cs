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

namespace ACR.Library.ACR.Education
{
public partial class CPIExpertMemberItem : CustomItem
{

    public static readonly string TemplateId = "{B124B371-0E02-456C-B316-A5A8DB1154CD}";

#region Inherited Base Templates

private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CPIExpertMemberItem(Item innerItem)
    : base(innerItem)
{
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator CPIExpertMemberItem(Item innerItem)
{
    return innerItem != null ? new CPIExpertMemberItem(innerItem) : null;
}

public static implicit operator Item(CPIExpertMemberItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField CPICategories
{
	get
	{
        return new CustomTreeListField(InnerItem, InnerItem.Fields["CPI Categories"]);
	}
}

public static string FieldName_CPICategories
{
	get
	{
        return "CPI Categories";
	}
}


public CustomTreeListField CPISpliceCategories
{
    get
    {
        return new CustomTreeListField(InnerItem, InnerItem.Fields["CPI Splice Categories"]);
    }
}

public static string FieldName_CPISpliceCategories
{
    get
    {
        return "CPI Splice Categories";
    }
}

public CustomCheckboxField IsCPISpliceExpert
{
    get
    {
        return new CustomCheckboxField(InnerItem, InnerItem.Fields["IsCPISpliceExpert"]);
    }
}

public static string FieldName_IsCPISpliceExpert
{
    get
    {
        return "IsCPISpliceExpert";
    }
} 


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


public CustomTextField Role
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Role"]);
	}
}

public static string FieldName_Role 
{
	get
	{
		return "Role";
	}
} 


public CustomTextField ShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Short Description"]);
	}
}

public static string FieldName_ShortDescription 
{
	get
	{
		return "Short Description";
	}
} 


public CustomTextField LongDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Long Description"]);
	}
}

public static string FieldName_LongDescription 
{
	get
	{
		return "Long Description";
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