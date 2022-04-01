using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Widgets;

namespace ACR.Library.ACR.Widgets.Specific
{
public partial class RelatedCoursesWidgetItem : CustomItem
{

public static readonly string TemplateId = "{AB1F1DAA-9A45-414A-A446-7F0695ED3961}";

#region Inherited Base Templates

private readonly WidgetBaseItem _WidgetBaseItem;
public WidgetBaseItem WidgetBase { get { return _WidgetBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public RelatedCoursesWidgetItem(Item innerItem) : base(innerItem)
{
	_WidgetBaseItem = new WidgetBaseItem(innerItem);

}

public static implicit operator RelatedCoursesWidgetItem(Item innerItem)
{
	return innerItem != null ? new RelatedCoursesWidgetItem(innerItem) : null;
}

public static implicit operator Item(RelatedCoursesWidgetItem customItem)
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


public CustomTextField LinkTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Title"]);
	}
}

public static string FieldName_LinkTitle 
{
	get
	{
		return "Link Title";
	}
} 


#endregion //Field Instance Methods
}
}