using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Widgets
{
public partial class FeaturedItem : CustomItem
{

public static readonly string TemplateId = "{5A0663E7-8C61-4750-9F8B-4F3D81C9E223}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public FeaturedItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator FeaturedItem(Item innerItem)
{
	return innerItem != null ? new FeaturedItem(innerItem) : null;
}

public static implicit operator Item(FeaturedItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField ContentItem
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Content Item"]);
	}
}

public static string FieldName_ContentItem 
{
	get
	{
		return "Content Item";
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


public CustomTextField LinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Text"]);
	}
}

public static string FieldName_LinkText 
{
	get
	{
		return "Link Text";
	}
} 


#endregion //Field Instance Methods
}
}