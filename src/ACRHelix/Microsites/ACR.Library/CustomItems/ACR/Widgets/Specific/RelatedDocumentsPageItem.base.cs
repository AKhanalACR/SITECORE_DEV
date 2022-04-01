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
public partial class RelatedDocumentsPageItem : CustomItem
{

public static readonly string TemplateId = "{CF67594E-490D-45C6-BB60-9BC2843F1B4C}";


#region Boilerplate CustomItem Code

public RelatedDocumentsPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator RelatedDocumentsPageItem(Item innerItem)
{
	return innerItem != null ? new RelatedDocumentsPageItem(innerItem) : null;
}

public static implicit operator Item(RelatedDocumentsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField RelatedResourceHeader
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Related Resource Header"]);
	}
}

public static string FieldName_RelatedResourceHeader 
{
	get
	{
		return "Related Resource Header";
	}
} 


public CustomTreeListField RelatedResources
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Related Resources"]);
	}
}

public static string FieldName_RelatedResources 
{
	get
	{
		return "Related Resources";
	}
} 


#endregion //Field Instance Methods
}
}