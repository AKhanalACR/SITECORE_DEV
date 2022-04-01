using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.AIRP.Base;

namespace ACR.Library.AIRP.Pages
{
public partial class InternalPageItem : CustomItem
{

public static readonly string TemplateId = "{6A16644D-AEAF-4140-B560-EDA9006A1FA6}";

#region Inherited Base Templates

private readonly NavigationItem _NavigationItem;
public NavigationItem Navigation { get { return _NavigationItem; } }
private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public InternalPageItem(Item innerItem) : base(innerItem)
{
	_NavigationItem = new NavigationItem(innerItem);
	_PageBaseItem = new PageBaseItem(innerItem);

}

public static implicit operator InternalPageItem(Item innerItem)
{
	return innerItem != null ? new InternalPageItem(innerItem) : null;
}

public static implicit operator Item(InternalPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Blurb
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Blurb"]);
	}
}


public CustomImageField HeaderImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Header Image"]);
	}
}


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}


#endregion //Field Instance Methods
}
}