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
public partial class AIRPHomepageItem : CustomItem
{

public static readonly string TemplateId = "{E1A00E17-BEAC-40CC-9B9F-3748645BD3AC}";

#region Inherited Base Templates

private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public AIRPHomepageItem(Item innerItem) : base(innerItem)
{
	_PageBaseItem = new PageBaseItem(innerItem);

}

public static implicit operator AIRPHomepageItem(Item innerItem)
{
	return innerItem != null ? new AIRPHomepageItem(innerItem) : null;
}

public static implicit operator Item(AIRPHomepageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField ActiveItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Active Items"]);
	}
}


public CustomTreeListField FeaturedContent
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Content"]);
	}
}


public CustomTextField HomeMissionStatementText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Home Mission Statement Text"]);
	}
}


public CustomImageField HomeMissionStatementImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Home Mission Statement Image"]);
	}
}


public CustomTextField AdvertisementJavaScript
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Advertisement JavaScript"]);
	}
}


#endregion //Field Instance Methods
}
}