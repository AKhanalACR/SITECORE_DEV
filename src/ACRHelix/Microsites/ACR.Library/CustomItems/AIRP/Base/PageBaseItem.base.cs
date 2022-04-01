using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.AIRP.Base
{
public partial class PageBaseItem : CustomItem
{

public static readonly string TemplateId = "{46471E4E-3FB2-4F83-8F78-235387812CC5}";


#region Boilerplate CustomItem Code

public PageBaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PageBaseItem(Item innerItem)
{
	return innerItem != null ? new PageBaseItem(innerItem) : null;
}

public static implicit operator Item(PageBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField ActiveButtons
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Active Buttons"]);
	}
}


public CustomTextField Metadata
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Metadata"]);
	}
}


public CustomMultiListField HotLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Hot Links"]);
	}
}


#endregion //Field Instance Methods
}
}