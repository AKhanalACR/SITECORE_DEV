using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates
{
public partial class _hasFactsItem : CustomItem
{
public static readonly string TemplateId = "{C5514443-A371-487D-BDB3-876BA6580DDB}";

#region Boilerplate CustomItem Code

public _hasFactsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasFactsItem(Item innerItem)
{
	return innerItem != null ? new _hasFactsItem(innerItem) : null;
}

public static implicit operator Item(_hasFactsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField LeadFact
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Lead Fact"]);
	}
}


public CustomMultiListField FeaturedFacts
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Featured Facts"]);
	}
}


public CustomImageField FactsLeadImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Facts Lead Image"]);
	}
}


#endregion //Field Instance Methods
}
}