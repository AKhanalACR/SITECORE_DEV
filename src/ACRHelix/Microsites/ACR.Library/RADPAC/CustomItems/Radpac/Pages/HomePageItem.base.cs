using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.Radpac.CustomItems.Radpac.Base;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
public partial class HomePageItem : CustomItem
{
    public static readonly string TemplateId = "{134367A1-A498-4EBB-92E3-0A4C236FDA8B}";
#region Inherited Base Templates

private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }

#endregion

#region Boilerplate CustomItem Code

public HomePageItem(Item innerItem) : base(innerItem)
{
	_MetadataItem = new MetadataItem(innerItem);
	_PageSettingsItem = new PageSettingsItem(innerItem);

}

public static implicit operator HomePageItem(Item innerItem)
{
	return innerItem != null ? new HomePageItem(innerItem) : null;
}

public static implicit operator Item(HomePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField SpotlightVideo
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Spotlight Video"]);
	}
}


public CustomImageField SpotlightImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Spotlight Image"]);
	}
}


public CustomTextField IntroductoryText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Introductory Text"]);
	}
}


public CustomTextField PledgeText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Pledge Text"]);
	}
}


public CustomImageField RSNAJournalCover
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["RSNA Journal Cover"]);
	}
}


public CustomTextField RSNAJournalText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["RSNA Journal Text"]);
	}
}


public CustomGeneralLinkField RSNAJournalLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["RSNA Journal Link"]);
	}
}


public CustomTextField RSNAJournalName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["RSNA Journal Name"]);
	}
}


#endregion //Field Instance Methods
}
}