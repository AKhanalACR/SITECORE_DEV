using System;
using System.IO;
using System.Text;
using System.Web.UI;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomItems.ACR.Interface.Wrappers;
using ACR.Library.Utils;
using System.Collections.Generic;
using Sitecore.Links;

namespace ACR.Library.ACR.MediaCenter
{
	public partial class SpokespersonItem : IAcrContent, IAcrPersonnel, INavigationItem
	{
		#region IAcrContent

		public string HeaderTitle
		{
			get { return "Spokesperson"; }
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
			get { return string.Empty; }
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
			get { return string.Empty; }
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

		#region IAcrPersonnel

		public string PersonnelName
		{
			get { return FullName; }
		}

		public string PersonnelImageUrl
		{
			get
			{
				//if we don't have an image then just return empty string
				if (Image == null)
				{
					return string.Empty;
				}

				//return our image sized properly
				return ImageUtil.GetScaledImageUrl(Image, 100, 0);
			}
		}

		public List<IAcrPersonnelDetail> ShortPersonnelDetails
		{
			get
			{
				//initialize our details list
				List<IAcrPersonnelDetail> details = new List<IAcrPersonnelDetail>();

				//for a spokespersons details we need to add position and location
				if (Position != null)
				{
					AcrPersonnelDetailWrapper position = new AcrPersonnelDetailWrapper();
					position.PersonnelDetailType = AcrPersonnelDetailType.Position;
					position.PersonnelDetailText = Position.Text;
					details.Add(position);
				}

				//return our details
				return details;
			}
		}

		public List<IAcrPersonnelDetail> PersonnelDetails
		{
			get
			{
				//initialize our details list
				List<IAcrPersonnelDetail> details = new List<IAcrPersonnelDetail>();

				//for a spokespersons details we need to add position and location
				if (Position != null)
				{
					AcrPersonnelDetailWrapper position = new AcrPersonnelDetailWrapper();
					position.PersonnelDetailType = AcrPersonnelDetailType.Position;
					position.PersonnelDetailText = Position.Text;
					details.Add(position);
				}

				if (Location != null)
				{
					AcrPersonnelDetailWrapper location = new AcrPersonnelDetailWrapper();
					location.PersonnelDetailType = AcrPersonnelDetailType.Location;
					location.PersonnelDetailText = Location.Text;
					details.Add(location);
				}

				//return our details
				return details;
			}
		}

		public string PersonnelBiography
		{
			get
			{
				//if we don't have a biography then return empty string
				if (Biography == null)
				{
					return string.Empty;
				}

				//return our biography text
				return Biography.Text;
			}
		}

		public string PersonnelUrl
		{
			get { return LinkManager.GetItemUrl(InnerItem); }
		}

		#endregion

		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get { return ContentTitle; }
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

		public string NavUrl
		{
			get { return LinkManager.GetItemUrl(InnerItem); }
		}

		public bool HideTextControl
		{
			get { return false; }
		}

		public bool HideToolbarControl
		{
			get { return false; }
		}

		#endregion
	}
}