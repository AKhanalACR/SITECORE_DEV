using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.MediaCenter
{
public partial class CpiExpertItem : CustomItem
{

    public static readonly string TemplateId = "{7AFAC7C6-3294-4391-9277-73481CDA0B58}";


#region Boilerplate CustomItem Code

    private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CpiExpertItem(Item innerItem) : base(innerItem)
{
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

  
public static implicit operator CpiExpertItem(Item innerItem)
{
	return innerItem != null ? new CpiExpertItem(innerItem) : null;
}

public static implicit operator Item(CpiExpertItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField Category
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Category"]);
	}
}

public static string FieldName_Category 
{
	get
	{
		return "Category";
	}
} 


public CustomTextField Name
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Name"]);
	}
}

public static string FieldName_Name 
{
	get
	{
		return "Name";
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


public CustomTextField FunctionalArea
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Functional Area"]);
	}
}

public static string FieldName_FunctionalArea 
{
	get
	{
		return "Functional Area";
	}
} 


public CustomTextField PhoneNumber
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Phone Number"]);
	}
}

public static string FieldName_PhoneNumber 
{
	get
	{
		return "Phone Number";
	}
} 


public CustomTextField Email
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Email"]);
	}
}

public static string FieldName_Email 
{
	get
	{
		return "Email";
	}
}

public CustomTextField Biography
{
    get
    {
        return new CustomTextField(InnerItem, InnerItem.Fields["Biography"]);
    }
}

public static string FieldName_Biography
{
    get
    {
        return "Biography";
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


public CustomTextField LongDescription
{
    get
    {
        return new CustomTextField(InnerItem, InnerItem.Fields["Long Description"]);
    }
}

public static string FieldName_LongDescription
{
    get
    {
        return "Long Description";
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

public CheckboxField IsCPISpliceExpert
{
    get
    {
        return new CheckboxField(InnerItem.Fields["isCpiSpliceExpert"]);
    }
}
public static string FieldName_IsCPISpliceExpert
{
    get

    {
        return "IsCPISpliceExpert";
    }
}

#endregion //Field Instance Methods
}
}