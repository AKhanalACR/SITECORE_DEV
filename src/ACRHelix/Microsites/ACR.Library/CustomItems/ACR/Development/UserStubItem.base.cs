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

namespace ACR.Library.ACR.Development
{
public partial class UserStubItem : CustomItem
{

public static readonly string TemplateId = "{85FF253F-59E3-4C5B-8907-B5D938F9E8C3}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }

#endregion

#region Boilerplate CustomItem Code

public UserStubItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);

}

public static implicit operator UserStubItem(Item innerItem)
{
	return innerItem != null ? new UserStubItem(innerItem) : null;
}

public static implicit operator Item(UserStubItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FirstName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["First Name"]);
	}
}

public static string FieldName_FirstName 
{
	get
	{
		return "First Name";
	}
} 


public CustomTextField MemberStatus
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Member Status"]);
	}
}

public static string FieldName_MemberStatus 
{
	get
	{
		return "Member Status";
	}
} 


public CustomTextField Username
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Username"]);
	}
}

public static string FieldName_Username 
{
	get
	{
		return "Username";
	}
} 


public CustomDateField MemberSince
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Member Since"]);
	}
}

public static string FieldName_MemberSince 
{
	get
	{
		return "Member Since";
	}
} 


public CustomTextField Action
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Action"]);
	}
}

public static string FieldName_Action 
{
	get
	{
		return "Action";
	}
} 


public CustomTextField LastName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Last Name"]);
	}
}

public static string FieldName_LastName 
{
	get
	{
		return "Last Name";
	}
} 


public CustomTextField Password
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Password"]);
	}
}

public static string FieldName_Password 
{
	get
	{
		return "Password";
	}
} 


public CustomTreeListField PurchaseHistory
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Purchase History"]);
	}
}

public static string FieldName_PurchaseHistory 
{
	get
	{
		return "Purchase History";
	}
} 


public CustomGeneralLinkField ActionLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Action Link"]);
	}
}

public static string FieldName_ActionLink 
{
	get
	{
		return "Action Link";
	}
} 


public CustomTextField LabelName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Label Name"]);
	}
}

public static string FieldName_LabelName 
{
	get
	{
		return "Label Name";
	}
} 


public CustomTreeListField Meetings
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Meetings"]);
	}
}

public static string FieldName_Meetings 
{
	get
	{
		return "Meetings";
	}
} 


public CustomTextField UserId
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["UserId"]);
	}
}

public static string FieldName_UserId 
{
	get
	{
		return "UserId";
	}
} 


public CustomTreeListField Committees
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Committees"]);
	}
}

public static string FieldName_Committees 
{
	get
	{
		return "Committees";
	}
} 


public CustomTextField MITStatus
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["MIT Status"]);
	}
}

public static string FieldName_MITStatus 
{
	get
	{
		return "MIT Status";
	}
} 


public CustomIntegerField CMECredits
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["CME Credits"]);
	}
}

public static string FieldName_CMECredits 
{
	get
	{
		return "CME Credits";
	}
} 


public CustomDateField ProfileModifiedDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Profile Modified Date"]);
	}
}

public static string FieldName_ProfileModifiedDate 
{
	get
	{
		return "Profile Modified Date";
	}
} 


public CustomTextField Chapter
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Chapter"]);
	}
}

public static string FieldName_Chapter 
{
	get
	{
		return "Chapter";
	}
} 


public CustomCheckboxField IsStaff
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Is Staff"]);
	}
}

public static string FieldName_IsStaff 
{
	get
	{
		return "Is Staff";
	}
} 


public CustomTreeListField Roles
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Roles"]);
	}
}

public static string FieldName_Roles 
{
	get
	{
		return "Roles";
	}
} 


#endregion //Field Instance Methods
}
}