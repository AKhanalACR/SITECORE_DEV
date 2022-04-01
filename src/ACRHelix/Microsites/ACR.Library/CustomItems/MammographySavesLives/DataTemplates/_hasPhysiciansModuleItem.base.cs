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
public partial class _hasPhysiciansModuleItem : CustomItem
{

public static readonly string TemplateId = "{0CE636EA-7110-45B8-BD93-92B2B665ACE3}";


#region Boilerplate CustomItem Code

public _hasPhysiciansModuleItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasPhysiciansModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasPhysiciansModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasPhysiciansModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField MarketingMaterialsTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Marketing Materials Title"]);
	}
}


public CustomMultiListField PhysiciansMediaItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Physicians Media Items"]);
	}
}


public CustomImageField PhysicianImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Physician Image"]);
	}
}


#endregion //Field Instance Methods
}
}