using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Content
{
public partial class ContentSubItem : CustomItem
{

public static readonly string TemplateId = "{425E1393-D56D-4802-9C60-93499B3D53D1}";


#region Boilerplate CustomItem Code

public ContentSubItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ContentSubItem(Item innerItem)
{
	return innerItem != null ? new ContentSubItem(innerItem) : null;
}

public static implicit operator Item(ContentSubItem customItem)
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


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}

public static string FieldName_Image 
{
	get
	{
		return "Image";
	}
} 


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}

public static string FieldName_Link 
{
	get
	{
		return "Link";
	}
} 


#endregion //Field Instance Methods
}
}