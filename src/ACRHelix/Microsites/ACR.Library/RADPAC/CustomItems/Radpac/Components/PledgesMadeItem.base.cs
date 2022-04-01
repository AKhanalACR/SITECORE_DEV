using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.Radpac.CustomItems.Radpac.Components
{
public partial class PledgesMadeItem : CustomItem
{
    public static readonly string TemplateId = "{04CFBE3E-A6B1-4521-B202-E225468C7EC6}";

#region Boilerplate CustomItem Code

public PledgesMadeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PledgesMadeItem(Item innerItem)
{
	return innerItem != null ? new PledgesMadeItem(innerItem) : null;
}

public static implicit operator Item(PledgesMadeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomIntegerField PledgeCount
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Pledge Count"]);
	}
}


#endregion //Field Instance Methods
}
}