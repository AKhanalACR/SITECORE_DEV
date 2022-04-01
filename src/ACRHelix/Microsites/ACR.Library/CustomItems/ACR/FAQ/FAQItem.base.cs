using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.FAQ
{
public partial class FAQItem : CustomItem
{

public static readonly string TemplateId = "{8BDCE161-5330-4423-B152-55ED73709DB8}";


#region Boilerplate CustomItem Code

public FAQItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FAQItem(Item innerItem)
{
	return innerItem != null ? new FAQItem(innerItem) : null;
}

public static implicit operator Item(FAQItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField FAQType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["FAQ Type"]);
	}
}

public static string FieldName_FAQType 
{
	get
	{
		return "FAQ Type";
	}
} 


public CustomTextField Question
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Question"]);
	}
}

public static string FieldName_Question 
{
	get
	{
		return "Question";
	}
} 


public CustomTextField Answer
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Answer"]);
	}
}

public static string FieldName_Answer 
{
	get
	{
		return "Answer";
	}
} 


#endregion //Field Instance Methods
}
}