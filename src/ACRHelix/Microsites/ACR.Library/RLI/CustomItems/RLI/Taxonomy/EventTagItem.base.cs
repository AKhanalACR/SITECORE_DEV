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
public partial class EventTagItem : CustomItem
{

public static readonly string TemplateId = "{3B5C7A14-04CC-4AA8-AD4B-FDD41DAC7076}";


#region Boilerplate CustomItem Code

public EventTagItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EventTagItem(Item innerItem)
{
	return innerItem != null ? new EventTagItem(innerItem) : null;
}

public static implicit operator Item(EventTagItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField EventTagTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Event Tag Title"]);
	}
}


#endregion //Field Instance Methods
}
}