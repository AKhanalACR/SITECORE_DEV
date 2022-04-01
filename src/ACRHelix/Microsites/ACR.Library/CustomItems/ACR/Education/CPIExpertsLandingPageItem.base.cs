using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Education
{
public partial class CPIExpertsLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{29F19EB5-E962-4619-BB1C-1FE9D91CABFA}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly BaseContentItem _BaseContentItem;
public BaseContentItem BaseContent { get { return _BaseContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CPIExpertsLandingPageItem(Item innerItem)
    : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_BaseContentItem = new BaseContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator CPIExpertsLandingPageItem(Item innerItem)
{
    return innerItem != null ? new CPIExpertsLandingPageItem(innerItem) : null;
}

public static implicit operator Item(CPIExpertsLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods

public static string FieldName_ShowCPISpliceMembers
{
    get
    {
        return "ShowCPISplice Members";
    }
}

public CustomCheckboxField ShowCPISpliceMembers
{
    get
    {
        return new CustomCheckboxField(InnerItem, InnerItem.Fields["ShowCPISplice Members"]);
    }
}


public static string FieldName_cpiImage
{
    get
    {
        return "cpiImage";
    }
}

public CustomImageField CpiImage
{
    get
    {
        return new CustomImageField(InnerItem, InnerItem.Fields["cpiImage"]);
    }
}


public static string FieldName_imageText
{
    get
    {
        return "imageText";
    }
}

public CustomTextField ImageText
{
    get
    {
        return new CustomTextField(InnerItem, InnerItem.Fields["imageText"]);
    }
}

public static string FieldName_introText
{
    get
    {
        return "introText";
    }
}

public CustomTextField IntroText
{
    get
    {
        return new CustomTextField(InnerItem, InnerItem.Fields["introText"]);
    }
}
#endregion //Field Instance Methods
}
}