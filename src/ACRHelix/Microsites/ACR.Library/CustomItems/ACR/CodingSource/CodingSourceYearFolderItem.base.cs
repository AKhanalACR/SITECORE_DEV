using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.CodingSource
{
public partial class CodingSourceYearFolderItem : CustomItem
{

public static readonly string TemplateId = "{947FA732-85AA-452E-83B3-9C9BD9F03EB3}";


#region Boilerplate CustomItem Code

public CodingSourceYearFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator CodingSourceYearFolderItem(Item innerItem)
{
	return innerItem != null ? new CodingSourceYearFolderItem(innerItem) : null;
}

public static implicit operator Item(CodingSourceYearFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Year
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Year"]);
	}
}

public static string FieldName_Year 
{
	get
	{
		return "Year";
	}
} 


#endregion //Field Instance Methods
}
}