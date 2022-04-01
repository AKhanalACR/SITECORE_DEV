using System;
using ACR.Library.Common.Interfaces;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Content
{
public partial class ContentSubItem : IListItemFeaturedParent
{
	#region Implementation of IListItemFeaturedParent

	public bool liSuppressParentPageFeature
	{
		get { return false; }
	}

	public CustomImageField liParentPageThumbnail
	{
		get { return Image; }
	}

	public CustomTextField liParentPageIntroText
	{
		get { return ShortDescription; }
	}

	public CustomTextField liPageTitle
	{
		get { return Title; }
	}

	public string NavUrl
	{
		get { return Link.Url; }
	}

	public bool liIsExternal
	{
		get { return !Link.Field.IsInternal; }
	}

	#endregion
}
}