using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class ContributorItem : CustomItem
{
public static readonly string TemplateId = "{601994CB-252E-460D-9A7A-DFCEB3D5E047}";

#region Boilerplate CustomItem Code

public ContributorItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ContributorItem(Item innerItem)
{
	return innerItem != null ? new ContributorItem(innerItem) : null;
}

public static implicit operator Item(ContributorItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FirstName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["First Name"]);
	}
}


public CustomTextField LastName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Last Name"]);
	}
}


public CustomTextField Employer
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Employer"]);
	}
}


public CustomTextField Location
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Location"]);
	}
}


#endregion //Field Instance Methods
}
}