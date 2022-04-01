using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI.Taxonomy
{
public partial class TimezoneItem : CustomItem
{

public static readonly string TemplateId = "{39E43B77-D272-40ED-8B64-BDE61536E8D1}";


#region Boilerplate CustomItem Code

public TimezoneItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator TimezoneItem(Item innerItem)
{
	return innerItem != null ? new TimezoneItem(innerItem) : null;
}

public static implicit operator Item(TimezoneItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TimezoneAbbreviation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Timezone Abbreviation"]);
	}
}

public static string FieldName_TimezoneAbbreviation 
{
	get
	{
		return "Timezone Abbreviation";
	}
} 


#endregion //Field Instance Methods
}
}