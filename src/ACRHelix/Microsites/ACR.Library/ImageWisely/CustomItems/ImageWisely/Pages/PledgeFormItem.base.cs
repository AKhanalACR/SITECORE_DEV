using System;
using Sitecore.Data.Items;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
public partial class PledgeFormItem : CustomItem
{
public static readonly string TemplateId = "{C70441ED-9E08-464F-81CF-36B1007C99DA}";
#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PledgeFormItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);
	_MetadataItem = new MetadataItem(innerItem);
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator PledgeFormItem(Item innerItem)
{
	return innerItem != null ? new PledgeFormItem(innerItem) : null;
}

public static implicit operator Item(PledgeFormItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField PledgeFormType
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Pledge Form Type"]);
	}
}


public CustomTextField OptionalTextBelowForm
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Optional Text Below Form"]);
	}
}


public CustomTextField SendFormDataTo
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Send Form Data To"]);
	}
}


public CustomTextField ConfirmationEmailFrom
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Confirmation Email From"]);
	}
}


public CustomTextField ConfirmationEmailSubject
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Confirmation Email Subject"]);
	}
}


public CustomTextField ConfirmationEmailBody
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Confirmation Email Body"]);
	}
}


public CustomTextField SubmissionFailureMessage
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Submission Failure Message"]);
	}
}


#endregion //Field Instance Methods
}
}