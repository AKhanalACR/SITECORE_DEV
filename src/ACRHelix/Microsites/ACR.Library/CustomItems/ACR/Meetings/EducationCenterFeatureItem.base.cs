using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Meetings
{
public partial class EducationCenterFeatureItem : CustomItem
{

public static readonly string TemplateId = "{82820B13-BF34-4A39-9E54-2D615708DA4F}";


#region Boilerplate CustomItem Code

public EducationCenterFeatureItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator EducationCenterFeatureItem(Item innerItem)
{
	return innerItem != null ? new EducationCenterFeatureItem(innerItem) : null;
}

public static implicit operator Item(EducationCenterFeatureItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField FeaturedName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Featured Name"]);
	}
}


public CustomImageField FeaturedThumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Featured Thumbnail"]);
	}
}


#endregion //Field Instance Methods
}
}