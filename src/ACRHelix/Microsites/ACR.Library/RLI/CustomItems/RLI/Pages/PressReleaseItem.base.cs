using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.RLI.Base;

namespace ACR.Library.RLI.Pages
{
public partial class PressReleaseItem : CustomItem
{

public static readonly string TemplateId = "{60C77E32-5028-4C5C-88B5-89CABABA6BAD}";

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

public PressReleaseItem(Item innerItem) : base(innerItem)
{
	_PageBaseItem = new PageBaseItem(innerItem);
	_BackgroundBaseItem = new BackgroundBaseItem(innerItem);
	_InternalPageBaseItem = new InternalPageBaseItem(innerItem);
	_WidgetPageBaseItem = new WidgetPageBaseItem(innerItem);

}

public static implicit operator PressReleaseItem(Item innerItem)
{
	return innerItem != null ? new PressReleaseItem(innerItem) : null;
}

public static implicit operator Item(PressReleaseItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomDateField Date
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Date"]);
	}
}


        public DateTime DateValue
        {
            get
            {
                DateField df = (DateField)InnerItem.Fields["Date"];
                return df.DateTime;
            }
        }

public static string FieldName_Date 
{
	get
	{
		return "Date";
	}
} 


#endregion //Field Instance Methods
}
}