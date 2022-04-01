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
public partial class DayOfWeekItem : CustomItem
{

public static readonly string TemplateId = "{131DF550-C364-4C94-9CAF-ACB9EE4A5926}";


#region Boilerplate CustomItem Code

public DayOfWeekItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator DayOfWeekItem(Item innerItem)
{
	return innerItem != null ? new DayOfWeekItem(innerItem) : null;
}

public static implicit operator Item(DayOfWeekItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Day
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Day"]);
	}
}


#endregion //Field Instance Methods
}
}