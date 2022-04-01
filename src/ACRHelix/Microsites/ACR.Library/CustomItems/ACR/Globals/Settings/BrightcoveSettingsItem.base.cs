using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ACR.Globals.Settings
{
public partial class BrightcoveSettingsItem : CustomItem
{

public static readonly string TemplateId = "{D86C11BA-7312-4B54-BD6A-6E784C3FBAD1}";


#region Boilerplate CustomItem Code

public BrightcoveSettingsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator BrightcoveSettingsItem(Item innerItem)
{
	return innerItem != null ? new BrightcoveSettingsItem(innerItem) : null;
}

public static implicit operator Item(BrightcoveSettingsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PlayerID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Player ID"]);
	}
}

public static string FieldName_PlayerID 
{
	get
	{
		return "Player ID";
	}
} 


public CustomIntegerField PlayerWidth
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Player Width"]);
	}
}

public static string FieldName_PlayerWidth 
{
	get
	{
		return "Player Width";
	}
} 


public CustomIntegerField PlayerHeight
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Player Height"]);
	}
}

public static string FieldName_PlayerHeight 
{
	get
	{
		return "Player Height";
	}
} 


public CustomTextField PlayerKey
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Player Key"]);
	}
}

public static string FieldName_PlayerKey 
{
	get
	{
		return "Player Key";
	}
} 


public CustomTextField PlaylistID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Playlist ID"]);
	}
}

public static string FieldName_PlaylistID 
{
	get
	{
		return "Playlist ID";
	}
} 


public CustomIntegerField PlaylistWidth
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Playlist Width"]);
	}
}

public static string FieldName_PlaylistWidth 
{
	get
	{
		return "Playlist Width";
	}
} 


public CustomIntegerField PlaylistHeight
{
	get
	{
		return new CustomIntegerField(InnerItem, InnerItem.Fields["Playlist Height"]);
	}
}

public static string FieldName_PlaylistHeight 
{
	get
	{
		return "Playlist Height";
	}
} 


public CustomTextField PlaylistKey
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Playlist Key"]);
	}
}

public static string FieldName_PlaylistKey 
{
	get
	{
		return "Playlist Key";
	}
} 


#endregion //Field Instance Methods
}
}