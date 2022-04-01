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
public partial class BackgroundBaseItem : CustomItem
{

public static readonly string TemplateId = "{B58FD615-CB95-46CA-9F43-C28FD802960C}";


#region Boilerplate CustomItem Code

public BackgroundBaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator BackgroundBaseItem(Item innerItem)
{
	return innerItem != null ? new BackgroundBaseItem(innerItem) : null;
}

public static implicit operator Item(BackgroundBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField BackgroundImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Background Image"]);
	}
}

public static string FieldName_BackgroundImage 
{
	get
	{
		return "Background Image";
	}
} 


#endregion //Field Instance Methods
}
}