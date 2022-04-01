using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MammographySavesLives.ContentItems
{
public partial class AudioDownloadFileItem : CustomItem
{

public static readonly string TemplateId = "{518D259A-25B0-4938-AEED-AECB54FB6B92}";


#region Boilerplate CustomItem Code

public AudioDownloadFileItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AudioDownloadFileItem(Item innerItem)
{
	return innerItem != null ? new AudioDownloadFileItem(innerItem) : null;
}

public static implicit operator Item(AudioDownloadFileItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AudioDownloadFileFormat
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Audio Download File Format"]);
	}
}


public CustomGeneralLinkField AudioDownloadFile
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Audio Download File"]);
	}
}


#endregion //Field Instance Methods
}
}