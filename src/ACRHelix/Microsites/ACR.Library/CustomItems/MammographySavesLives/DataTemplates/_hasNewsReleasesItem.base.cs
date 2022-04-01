using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MammographySavesLives.DataTemplates
{
public partial class _hasNewsReleasesItem : CustomItem
{

public static readonly string TemplateId = "{F06CEFAB-9DCE-43AD-AD11-BB8F73989ECB}";


#region Boilerplate CustomItem Code

public _hasNewsReleasesItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasNewsReleasesItem(Item innerItem)
{
	return innerItem != null ? new _hasNewsReleasesItem(innerItem) : null;
}

public static implicit operator Item(_hasNewsReleasesItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField NewsReleasesTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["News Releases Title"]);
	}
}


public CustomMultiListField NewsReleases
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["News Releases"]);
	}
}


public CustomCheckboxField TwoColumn
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Two Column"]);
	}
}


#endregion //Field Instance Methods
}
}