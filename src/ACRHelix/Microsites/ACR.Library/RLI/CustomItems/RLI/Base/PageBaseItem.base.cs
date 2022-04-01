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
public partial class PageBaseItem : CustomItem
{

public static readonly string TemplateId = "{87EA1C5D-00BC-4A63-B8CB-EBAA9D80995F}";


#region Boilerplate CustomItem Code

public PageBaseItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PageBaseItem(Item innerItem)
{
	return innerItem != null ? new PageBaseItem(innerItem) : null;
}

public static implicit operator Item(PageBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}

public static string FieldName_Title 
{
	get
	{
		return "Title";
	}
} 


public CustomTextField MetadataKeywords
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Metadata Keywords"]);
	}
}

public static string FieldName_MetadataKeywords 
{
	get
	{
		return "Metadata Keywords";
	}
} 


public CustomTextField MetadataDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Metadata Description"]);
	}
}

public static string FieldName_MetadataDescription 
{
	get
	{
		return "Metadata Description";
	}
} 


#endregion //Field Instance Methods
}
}