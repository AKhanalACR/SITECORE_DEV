using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Meetings
{
	public partial class LiveMeetingsPageItem : IListItemFeaturedParent, ICourseMaterials
	{

		public bool liSuppressParentPageFeature
		{
			get { return SuppressParentPageFeature.Checked; }
		}

		public CustomImageField liParentPageThumbnail
		{
			get { return ParentPageThumbnail; }
		}

		public CustomTextField liParentPageIntroText
		{
			get { return ParentPageIntroText; }
		}

		public CustomTextField liPageTitle
		{
			get { return BasePage.ShortTitle; }
		}

		public string NavUrl
		{
			get { return BasePage.NavUrl; }
		}

		public bool liIsExternal
		{
			get { return false; }
		}
	}
}