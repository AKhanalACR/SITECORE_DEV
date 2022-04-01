using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.Common.CustomItems.AcrCommon
{
public partial class RobotsTxtItem : CustomItem
{
public static readonly string TemplateId = "{FD474820-9867-4BF1-87DC-0120092804C2}";

#region Boilerplate CustomItem Code

public RobotsTxtItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RobotsTxtItem(Item innerItem)
{
	return innerItem != null ? new RobotsTxtItem(innerItem) : null;
}

public static implicit operator Item(RobotsTxtItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Robotstxt
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Robots txt"]);
	}
}


#endregion //Field Instance Methods
}
}