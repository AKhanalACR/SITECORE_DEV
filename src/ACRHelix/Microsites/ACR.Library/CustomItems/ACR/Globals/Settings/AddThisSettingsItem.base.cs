using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Globals.Settings
{
public partial class AddThisSettingsItem : CustomItem
{

public static readonly string TemplateId = "{00C02AF5-2F66-4F84-90AE-BC95F1588691}";


#region Boilerplate CustomItem Code

public AddThisSettingsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AddThisSettingsItem(Item innerItem)
{
	return innerItem != null ? new AddThisSettingsItem(innerItem) : null;
}

public static implicit operator Item(AddThisSettingsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PublicID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Public ID"]);
	}
}

public static string FieldName_PublicID 
{
	get
	{
		return "Public ID";
	}
} 


#endregion //Field Instance Methods
}
}