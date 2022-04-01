using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.Globals.Coveo
{
public partial class MediaTypeAssociationItem : CustomItem
{

public static readonly string TemplateId = "{FFB7C820-51ED-4E45-8078-711B8F9A46C8}";


#region Boilerplate CustomItem Code

public MediaTypeAssociationItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator MediaTypeAssociationItem(Item innerItem)
{
	return innerItem != null ? new MediaTypeAssociationItem(innerItem) : null;
}

public static implicit operator Item(MediaTypeAssociationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField MediaRoot
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Media Root"]);
	}
}

public static string FieldName_MediaRoot 
{
	get
	{
		return "Media Root";
	}
} 


public CustomTextField FacetName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Facet Name"]);
	}
}

public static string FieldName_FacetName 
{
	get
	{
		return "Facet Name";
	}
} 


#endregion //Field Instance Methods
}
}