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
public partial class AudioDownloadItem : CustomItem
{

public static readonly string TemplateId = "{888591CF-CE46-4F24-A650-9A5BAB510DC6}";


#region Boilerplate CustomItem Code

public AudioDownloadItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AudioDownloadItem(Item innerItem)
{
	return innerItem != null ? new AudioDownloadItem(innerItem) : null;
}

public static implicit operator Item(AudioDownloadItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField AudioDownloadTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Audio Download Title"]);
	}
}


#endregion //Field Instance Methods
}
}