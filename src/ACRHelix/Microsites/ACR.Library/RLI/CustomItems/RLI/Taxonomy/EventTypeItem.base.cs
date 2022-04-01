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
public partial class EventTypeItem : CustomItem
{

public static readonly string TemplateId = "{56D1C5C3-7B90-4E97-B20F-CD4C7B562A73}";


#region Boilerplate CustomItem Code

public EventTypeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EventTypeItem(Item innerItem)
{
	return innerItem != null ? new EventTypeItem(innerItem) : null;
}

public static implicit operator Item(EventTypeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField EventTypeTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Type Title"]);
	}
}


#endregion //Field Instance Methods
}
}