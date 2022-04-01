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
public partial class EventLevelItem : CustomItem
{

public static readonly string TemplateId = "{59FDBCCD-260F-4D36-A070-A17805E7E2BA}";


#region Boilerplate CustomItem Code

public EventLevelItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EventLevelItem(Item innerItem)
{
	return innerItem != null ? new EventLevelItem(innerItem) : null;
}

public static implicit operator Item(EventLevelItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Level
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Level"]);
	}
}


#endregion //Field Instance Methods
}
}