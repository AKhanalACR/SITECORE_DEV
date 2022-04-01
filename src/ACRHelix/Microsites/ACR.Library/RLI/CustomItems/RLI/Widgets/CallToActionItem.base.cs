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
public partial class CallToActionItem : CustomItem
{

public static readonly string TemplateId = "{6BEC54AF-D561-45E2-AED5-152FF6B182ED}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public CallToActionItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator CallToActionItem(Item innerItem)
{
	return innerItem != null ? new CallToActionItem(innerItem) : null;
}

public static implicit operator Item(CallToActionItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Header
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Header"]);
	}
}

public static string FieldName_Title 
{
	get
	{
		return "Title";
	}
} 


public CustomImageField Icon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon"]);
	}
}

public static string FieldName_Icon 
{
	get
	{
		return "Icon";
	}
} 


public CustomTextField SubheaderText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Subheader Text"]);
	}
}

public static string FieldName_SubheaderText 
{
	get
	{
		return "Subheader Text";
	}
} 


public CustomLookupField Button
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Button"]);
	}
}

public static string FieldName_Button 
{
	get
	{
		return "Button";
	}
} 


public CustomTextField BottomText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Bottom Text"]);
	}
}

public static string FieldName_BottomText 
{
	get
	{
		return "Bottom Text";
	}
} 


#endregion //Field Instance Methods
}
}