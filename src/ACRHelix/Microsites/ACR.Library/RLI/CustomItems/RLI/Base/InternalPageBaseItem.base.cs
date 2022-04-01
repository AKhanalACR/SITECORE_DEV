using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI.Base
{
public partial class InternalPageBaseItem : CustomItem
{

public static readonly string TemplateId = "{9A45DA49-3E8F-4F24-AC7D-325D8344E24A}";


#region Boilerplate CustomItem Code

public InternalPageBaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator InternalPageBaseItem(Item innerItem)
{
	return innerItem != null ? new InternalPageBaseItem(innerItem) : null;
}

public static implicit operator Item(InternalPageBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ShortDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Short Description"]);
	}
}

public static string FieldName_ShortDescription 
{
	get
	{
		return "Short Description";
	}
} 


public CustomTextField Body
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body"]);
	}
}

public static string FieldName_Body 
{
	get
	{
		return "Body";
	}
} 


#endregion //Field Instance Methods
}
}