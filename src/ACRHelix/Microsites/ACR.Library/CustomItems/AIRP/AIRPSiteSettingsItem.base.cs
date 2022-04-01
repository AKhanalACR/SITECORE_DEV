using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.AIRP
{
public partial class AIRPSiteSettingsItem : CustomItem
{

public static readonly string TemplateId = "{14177C6A-63BE-4794-A678-E87EE0455CFE}";


#region Boilerplate CustomItem Code

public AIRPSiteSettingsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AIRPSiteSettingsItem(Item innerItem)
{
	return innerItem != null ? new AIRPSiteSettingsItem(innerItem) : null;
}

public static implicit operator Item(AIRPSiteSettingsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField BannerImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Banner Image"]);
	}
}


public CustomTextField BreadcrumbDelimiter
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Breadcrumb Delimiter"]);
	}
}


public CustomImageField HeaderLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Header Logo"]);
	}
}


public CustomTextField RelatedLinksTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Related Links Title"]);
	}
}


public CustomMultiListField SideLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Side Links"]);
	}
}


public CustomTextField BannerText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Banner Text"]);
	}
}


public CustomGeneralLinkField CopyrightLinkUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Copyright Link Url"]);
	}
}


public CustomMultiListField HeaderTopLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Header Top Links"]);
	}
}


public CustomGeneralLinkField BannerLinkUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Banner Link Url"]);
	}
}


public CustomTextField CopyrightLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Copyright Link Text"]);
	}
}


public CustomTextField FacebookURL
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Facebook URL"]);
	}
}


public CustomTextField BannerLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Banner Link Text"]);
	}
}


public CustomGeneralLinkField PrivacyPolicyLinkUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Privacy Policy Link Url"]);
	}
}


public CustomTextField TwitterURL
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Twitter URL"]);
	}
}


public CustomTextField PrivacyPolicyLinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Privacy Policy Link Text"]);
	}
}


public CustomTextField YouTubeURL
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["YouTube URL"]);
	}
}


public CustomImageField ACRLogo
{
      get
      {
        return new CustomImageField(InnerItem, InnerItem.Fields["ACR Logo"]);
      }
}

public CustomTextField ACRLogoLink
{
      get
      {
        return new CustomTextField(InnerItem, InnerItem.Fields["ACR Logo Link"]);
      }
}

#endregion //Field Instance Methods
}
}