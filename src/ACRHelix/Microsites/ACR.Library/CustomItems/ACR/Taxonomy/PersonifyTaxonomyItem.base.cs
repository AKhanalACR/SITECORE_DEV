using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.Taxonomy
{
public partial class PersonifyTaxonomyItem : CustomItem
{

public static readonly string TemplateId = "{063C8E34-BB41-4209-8F3D-C2D1DD2E3745}";


#region Boilerplate CustomItem Code

public PersonifyTaxonomyItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PersonifyTaxonomyItem(Item innerItem)
{
	return innerItem != null ? new PersonifyTaxonomyItem(innerItem) : null;
}

public static implicit operator Item(PersonifyTaxonomyItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PersonifyID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Personify ID"]);
	}
}

public static string FieldName_PersonifyID 
{
	get
	{
		return "Personify ID";
	}
} 


public CustomTextField DisplayName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Display Name"]);
	}
}

public static string FieldName_DisplayName 
{
	get
	{
		return "Display Name";
	}
} 


public CustomCheckboxField OmitfromSearch
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Omit from Search"]);
	}
}

public static string FieldName_OmitfromSearch 
{
	get
	{
		return "Omit from Search";
	}
} 


#endregion //Field Instance Methods
}
}