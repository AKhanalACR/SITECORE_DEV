using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.Radpac.CustomItems.Radpac.Base
{
public partial class ContentPageItem : CustomItem
{
    public static readonly string TemplateId = "{1F61ACDA-5D2A-4B9B-B7DC-F9E17201348A}";

#region Boilerplate CustomItem Code

public ContentPageItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ContentPageItem(Item innerItem)
{
	return innerItem != null ? new ContentPageItem(innerItem) : null;
}

public static implicit operator Item(ContentPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField OptionalFloatedImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Optional Floated Image"]);
	}
}


public CustomTextField BodyText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Body Text"]);
	}
}


public CustomTextField Optionalembeddedvideo
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Optional embedded video"]);
	}
}


public CustomCheckboxField DisplayPatientImagingCard
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display Patient Imaging Card"]);
	}
}


public CustomMultiListField RightColumnModules
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Right Column Modules"]);
	}
}


#endregion //Field Instance Methods
}
}