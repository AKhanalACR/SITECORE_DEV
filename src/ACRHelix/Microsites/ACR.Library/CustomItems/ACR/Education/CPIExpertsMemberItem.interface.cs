using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Wrappers;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomItems.ACR.Interface.Wrappers;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Education
{
	public partial class CPIExpertMemberItem : IAcrContent, IAcrPersonnel, INavigationItem
	{
		#region IAcrContent

		public string HeaderTitle
		{
			get { return "Expert"; }
		}

		public string ContentTitle
		{
			get { return PersonnelName; }
		}

		public string ContentSubTitle
		{
			get { return string.Empty; }
		}

		public DateTime ContentDate
		{
			get { return DateTime.MinValue; }
		}

		public string ContentAuthor
		{
			get { return string.Empty; }
		}

		public string ContentImageUrl
		{
			get { return Image.MediaUrl; }
		}

		public bool ReplacePageTitleBannerWithHeaderImage
		{
			get
			{
				return false;
			}
		}

		public string ContentBodyText
		{
			get { return LongDescription.Text; }
		}

		public string ContentAdditionalInformation
		{
			get { return string.Empty; }
		}

		public string ContentResourceTitle
		{
			get { return string.Empty; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return new List<IListItem>(0); }
		}

		public string ContentProductsTitle
		{
			get { return string.Empty; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return new List<ProductStubItem>(0); }
		}

		#endregion

		#region Implementation of IAcrPersonnel

		public string PersonnelName
		{
			get { return Name.Text; }
		}

		public string PersonnelImageUrl
		{
			get
			{
				if (Image.MediaItem == null)
				{
					return string.Empty;
				}
				return ImageUtil.GetScaledImageUrl(Image, 100, 0);
			}
		}

		public List<IAcrPersonnelDetail> ShortPersonnelDetails
		{
			get { return new List<IAcrPersonnelDetail>(); }
		}

		private List<IAcrPersonnelDetail> _personnelDetails; 
		public List<IAcrPersonnelDetail> PersonnelDetails
		{
			get
			{
				if (_personnelDetails == null)
				{
					_personnelDetails = new List<IAcrPersonnelDetail>();
					if (Role != null)
					{
						AcrPersonnelDetailWrapper position = new AcrPersonnelDetailWrapper();
						position.PersonnelDetailType = AcrPersonnelDetailType.Position;
						position.PersonnelDetailText = Role.Text;
						_personnelDetails.Add(position);
					}
					if (!string.IsNullOrEmpty(LongDescription.Text))
					{
						AcrPersonnelDetailWrapper position = new AcrPersonnelDetailWrapper();
						position.PersonnelDetailType = AcrPersonnelDetailType.FunctionalArea;
						position.PersonnelDetailText = LongDescription.Text;
						_personnelDetails.Add(position);
					}
				}
				return _personnelDetails;
			}
		}

		public string PersonnelBiography
		{
			get { return BodyText.Text; }
		}

		public string PersonnelUrl
		{
			get { return LinkManager.GetItemUrl(InnerItem); }
		}

		#endregion

		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get { return Name.Text; }
		}

		public bool HideBreadcrumb
		{
			get { return false; }
		}

		public bool ShowInTopNavigation
		{
			get { return false; }
		}

		public bool ShowInSideNavigation
		{
			get { return false; }
		}

		public bool ShowInFooter
		{
			get { return false; }
		}

		public bool ShowInSitemap
		{
			get { return false; }
		}

		public bool HideSideNavigation
		{
			get { return false; }
		}

		public bool HideTextControl
		{
			get { return false; }
		}

		public bool HideToolbarControl
		{
			get { return false; }
		}

		public string NavUrl
		{
			get { return LinkManager.GetItemUrl(InnerItem); }
		}

		#endregion
	}
}