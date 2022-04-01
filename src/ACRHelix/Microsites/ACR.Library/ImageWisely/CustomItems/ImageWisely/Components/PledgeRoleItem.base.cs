using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class PledgeRoleItem : CustomItem
{

public static readonly string TemplateId = "{B12E6BB5-6B62-4D2D-9E50-FCAF7C04E76D}";


#region Boilerplate CustomItem Code

public PledgeRoleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PledgeRoleItem(Item innerItem)
{
	return innerItem != null ? new PledgeRoleItem(innerItem) : null;
}

public static implicit operator Item(PledgeRoleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PledgePrefixText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Pledge Prefix Text"]);
	}
}

public static string FieldName_PledgePrefixText 
{
	get
	{
		return "Pledge Prefix Text";
	}
} 


public CustomTextField PledgeRoleName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Pledge Role Name"]);
	}
}

public static string FieldName_PledgeRoleName 
{
	get
	{
		return "Pledge Role Name";
	}
} 


public CustomTextField PledgeSuffixText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Pledge Suffix Text"]);
	}
}

public static string FieldName_PledgeSuffixText 
{
	get
	{
		return "Pledge Suffix Text";
	}
} 


public CustomLookupField PledgeRoleForm
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Pledge Role Form"]);
	}
}

public static string FieldName_PledgeRoleForm 
{
	get
	{
		return "Pledge Role Form";
	}
} 


public CustomTextField HelpText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Help Text"]);
	}
}

public static string FieldName_HelpText 
{
	get
	{
		return "Help Text";
	}
} 


#endregion //Field Instance Methods
}
}