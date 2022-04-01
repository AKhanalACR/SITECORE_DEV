using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class PatientImagingHistoryCardItem : CustomItem
{
public static readonly string TemplateId = "{4E847D1F-81A2-480E-8C44-D26B73B7AA7C}";

#region Boilerplate CustomItem Code

public PatientImagingHistoryCardItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator PatientImagingHistoryCardItem(Item innerItem)
{
	return innerItem != null ? new PatientImagingHistoryCardItem(innerItem) : null;
}

public static implicit operator Item(PatientImagingHistoryCardItem customItem)
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


public CustomTextField WalletTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Wallet Title"]);
	}
}


public CustomGeneralLinkField CardLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Card Link"]);
	}
}


public CustomGeneralLinkField WalletLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Wallet Link"]);
	}
}


public CustomTextField Description
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Description"]);
	}
}


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}


#endregion //Field Instance Methods
}
}