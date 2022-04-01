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
public partial class LoginPageItem : CustomItem
{

    public static readonly string TemplateId = "{BD9ADD15-E455-499D-982C-0D38B1FC2369}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }
#endregion

#region Boilerplate CustomItem Code

public LoginPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
    _PageSettingsItem = new PageSettingsItem(innerItem);
    _MetadataItem = new MetadataItem(innerItem);
    _ContentPageItem = new ContentPageItem(innerItem);
}

public static implicit operator LoginPageItem(Item innerItem)
{
	return innerItem != null ? new LoginPageItem(innerItem) : null;
}

public static implicit operator Item(LoginPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}