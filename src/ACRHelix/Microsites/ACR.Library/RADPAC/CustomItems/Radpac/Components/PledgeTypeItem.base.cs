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
public partial class PledgeTypeItem : CustomItem
{
    public static readonly string TemplateId = "{ABB8BE48-659F-47AD-B1BA-58BB27B74D13}";

#region Boilerplate CustomItem Code

public PledgeTypeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PledgeTypeItem(Item innerItem)
{
	return innerItem != null ? new PledgeTypeItem(innerItem) : null;
}

public static implicit operator Item(PledgeTypeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PledgeTypeName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Pledge Type Name"]);
	}
}


#endregion //Field Instance Methods
}
}