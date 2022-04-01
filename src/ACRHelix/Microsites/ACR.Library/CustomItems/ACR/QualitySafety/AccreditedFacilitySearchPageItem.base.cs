using Sitecore.Data.Items;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.CustomItems.ACR.QualitySafety
{
public partial class AccreditedFacilitySearchPageItem : CustomItem
{

public static readonly string TemplateId = "{478D9CA4-BA99-42A6-B639-2ACDB725AA98}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AccreditedFacilitySearchPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator AccreditedFacilitySearchPageItem(Item innerItem)
{
	return innerItem != null ? new AccreditedFacilitySearchPageItem(innerItem) : null;
}

public static implicit operator Item(AccreditedFacilitySearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


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