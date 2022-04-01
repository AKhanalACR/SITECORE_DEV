using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.Content
{
public partial class CurrentBillItem : CustomItem
{

public static readonly string TemplateId = "{72835307-88A1-4F88-8799-69CD198F3C22}";


#region Boilerplate CustomItem Code

public CurrentBillItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator CurrentBillItem(Item innerItem)
{
	return innerItem != null ? new CurrentBillItem(innerItem) : null;
}

public static implicit operator Item(CurrentBillItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField BillNumber
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Bill Number"]);
	}
}

public static string FieldName_BillNumber 
{
	get
	{
		return "Bill Number";
	}
} 


public CustomTextField BillTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Bill Title"]);
	}
}

public static string FieldName_BillTitle 
{
	get
	{
		return "Bill Title";
	}
} 


public CustomDateField BillDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Bill Date"]);
	}
}

public static string FieldName_BillDate 
{
	get
	{
		return "Bill Date";
	}
} 


public CustomTextField RecentAction
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Recent Action"]);
	}
}

public static string FieldName_RecentAction 
{
	get
	{
		return "Recent Action";
	}
} 


public CustomTextField Sponsor
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Sponsor"]);
	}
}

public static string FieldName_Sponsor 
{
	get
	{
		return "Sponsor";
	}
} 


public CustomTextField CoSponsors
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["CoSponsors"]);
	}
}

public static string FieldName_CoSponsors 
{
	get
	{
		return "CoSponsors";
	}
} 


public CustomTextField Summary
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Summary"]);
	}
}

public static string FieldName_Summary 
{
	get
	{
		return "Summary";
	}
} 


public CustomTextField AdditionalInformation
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Additional Information"]);
	}
}

public static string FieldName_AdditionalInformation 
{
	get
	{
		return "Additional Information";
	}
} 


#endregion //Field Instance Methods
}
}