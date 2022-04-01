using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Base
{
public partial class EventBaseItem : CustomItem
{

public static readonly string TemplateId = "{C9CA6A88-9A3E-47AD-B7FA-F30FAF33890A}";

#region Inherited Base Templates

private readonly PageBaseItem _PageBaseItem;
public PageBaseItem PageBase { get { return _PageBaseItem; } }
private readonly BackgroundBaseItem _BackgroundBaseItem;
public BackgroundBaseItem BackgroundBase { get { return _BackgroundBaseItem; } }
private readonly InternalPageBaseItem _InternalPageBaseItem;
public InternalPageBaseItem InternalPageBase { get { return _InternalPageBaseItem; } }
private readonly WidgetPageBaseItem _WidgetPageBaseItem;
public WidgetPageBaseItem WidgetPageBase { get { return _WidgetPageBaseItem; } }

#endregion

#region Boilerplate CustomItem Code

public EventBaseItem(Item innerItem) : base(innerItem)
{
	_PageBaseItem = new PageBaseItem(innerItem);
	_BackgroundBaseItem = new BackgroundBaseItem(innerItem);
	_InternalPageBaseItem = new InternalPageBaseItem(innerItem);
	_WidgetPageBaseItem = new WidgetPageBaseItem(innerItem);

}

public static implicit operator EventBaseItem(Item innerItem)
{
	return innerItem != null ? new EventBaseItem(innerItem) : null;
}

public static implicit operator Item(EventBaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField LecturerName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Lecturer Name"]);
	}
}

public static string FieldName_LecturerName 
{
	get
	{
		return "Lecturer Name";
	}
} 


public CustomMultiListField Level
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Level"]);
	}
}

public static string FieldName_Level 
{
	get
	{
		return "Level";
	}
} 


public CustomGeneralLinkField RegistrationLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Registration Link"]);
	}
}

public static string FieldName_RegistrationLink 
{
	get
	{
		return "Registration Link";
	}
} 


public CustomMultiListField Tags
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Tags"]);
	}
}

public static string FieldName_Tags 
{
	get
	{
		return "Tags";
	}
} 


public CustomLookupField Type
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Type"]);
	}
}

public static string FieldName_Type 
{
	get
	{
		return "Type";
	}
} 


public CustomDateField StartDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Start Date"]);
	}
}

        public DateTime StartDateTime
        {
            get
            {
                return StartDate.DateTime;
            }
        }

public static string FieldName_StartDate 
{
	get
	{
		return "Start Date";
	}
} 


#endregion //Field Instance Methods
}
}