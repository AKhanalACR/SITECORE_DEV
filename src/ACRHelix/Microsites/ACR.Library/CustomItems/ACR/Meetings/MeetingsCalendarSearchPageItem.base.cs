using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Meetings
{
public partial class MeetingsCalendarSearchPageItem : CustomItem
{

public static readonly string TemplateId = "{B1EC2CDE-6A04-4373-838B-1E8C0D6860B7}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public MeetingsCalendarSearchPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);

}

public static implicit operator MeetingsCalendarSearchPageItem(Item innerItem)
{
	return innerItem != null ? new MeetingsCalendarSearchPageItem(innerItem) : null;
}

public static implicit operator Item(MeetingsCalendarSearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}