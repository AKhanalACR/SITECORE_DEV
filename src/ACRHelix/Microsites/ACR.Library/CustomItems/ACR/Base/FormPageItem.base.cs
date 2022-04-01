using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Base
{
public partial class FormPageItem : CustomItem
{

public static readonly string TemplateId = "{8BE4F0B4-B73C-49C0-B72D-483896FCAEB2}";


#region Boilerplate CustomItem Code

public FormPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FormPageItem(Item innerItem)
{
	return innerItem != null ? new FormPageItem(innerItem) : null;
}

public static implicit operator Item(FormPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField SendToEmail
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Send To Email"]);
	}
}

public static string FieldName_SendToEmail 
{
	get
	{
		return "Send To Email";
	}
} 


public CustomTextField ConfirmationText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Confirmation Text"]);
	}
}

public static string FieldName_ConfirmationText 
{
	get
	{
		return "Confirmation Text";
	}
} 


public CustomTextField ErrorText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Error Text"]);
	}
}

public static string FieldName_ErrorText 
{
	get
	{
		return "Error Text";
	}
} 


#endregion //Field Instance Methods
}
}