using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Widgets;

namespace ACR.Library.ACR.Widgets.General
{
public partial class RichTextWidgetItem : CustomItem
{

public static readonly string TemplateId = "{9C16C139-953D-44D5-AA34-7AE8BD7FED61}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RichTextWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator RichTextWidgetItem(Item innerItem)
{
	return innerItem != null ? new RichTextWidgetItem(innerItem) : null;
}

public static implicit operator Item(RichTextWidgetItem customItem)
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


public CustomTextField BodyText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body Text"]);
	}
}

public static string FieldName_BodyText 
{
	get
	{
		return "Body Text";
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