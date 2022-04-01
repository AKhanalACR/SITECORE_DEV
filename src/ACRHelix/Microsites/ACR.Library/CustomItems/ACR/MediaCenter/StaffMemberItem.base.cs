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
public partial class StaffMemberItem : CustomItem
{

public static readonly string TemplateId = "{8FD77D06-98C0-46EF-B1EF-6E833055B552}";


#region Boilerplate CustomItem Code

public StaffMemberItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator StaffMemberItem(Item innerItem)
{
	return innerItem != null ? new StaffMemberItem(innerItem) : null;
}

public static implicit operator Item(StaffMemberItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField Category
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Category"]);
	}
}

public static string FieldName_Category 
{
	get
	{
		return "Category";
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


public CustomTextField FunctionalArea
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Functional Area"]);
	}
}

public static string FieldName_FunctionalArea 
{
	get
	{
		return "Functional Area";
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


public CustomTextField Email
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Email"]);
	}
}

public static string FieldName_Email 
{
	get
	{
		return "Email";
	}
} 


#endregion //Field Instance Methods
}
}