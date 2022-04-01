using System;
using System.Text;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Content
{
	public partial class CurrentBillItem : IListItem, IAcrContent, INavigationItem

{
	#region IListItem

	public string LiTopic
	{
		get { return string.Empty; }
	}

	public string LiTitle
	{
		get { return ContentTitle; }
	}

	public string LiDescription
	{
		get { return Summary.Text; }
	}

	public string LiUrl
	{
		get { return LinkUtils.GetItemFullUrl(InnerItem); }
	}

	public string LiLinkTarget
	{
		get { return string.Empty; }
	}

	public bool LiIsPdf
	{
		get { return false; }
	}

	public string LiAssociatedPdfUrl
	{
		get { return string.Empty; }
	}

	public string LiType
	{
		get { return "Current Bill"; }
	}

	public DateTime LiDate
	{
		get { return BillDate.DateTime; }
	}

	public MediaItem LiImage
	{
		get { return null; }
	}

	#endregion

		#region Implementation of IAcrContent

		public string HeaderTitle
		{
			get { return "Current Bills"; }
		}

		public string ContentSubTitle
		{
			get { return string.Empty; }
		}

		public string ContentTitle
		{
			get
			{
				if (!string.IsNullOrEmpty(BillTitle.Text))
				{
					if (!string.IsNullOrEmpty(BillNumber.Text))
					{
						return string.Format("{0} ({1})", BillNumber.Text, BillTitle.Text);
					}
					return BillTitle.Text;
				}
				return string.Empty;
			}
		}

		public DateTime ContentDate
		{
			get { return BillDate.DateTime; }
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
			get
			{
				StringBuilder sb = new StringBuilder();
				bool hasSponsor= false;
				if (!string.IsNullOrEmpty(Sponsor.Text))
				{
					sb.Append("<span class=\"header-sixth\" >Sponsor: ")
						.Append(Sponsor.Text).Append("</span>\n");
					hasSponsor = true;
				}
				if (!string.IsNullOrEmpty(CoSponsors.Text))
				{
					sb.Append("<span class=\"header-sixth\" >Co-sponsor: ")
						.Append(CoSponsors.Text).Append("</span>\n");
					hasSponsor = true;
				}
				if (hasSponsor)
				{
					sb.Append("<br/>");
				}
				if (!string.IsNullOrEmpty(RecentAction.Text))
				{
					sb.Append("<p>").Append(RecentAction.Text).Append("</p>\n");
				}
				sb.Append(Summary.Text);
				return sb.ToString();
			}
		}

		public string ContentAdditionalInformation
		{
			get { return AdditionalInformation.Text; }
		}

		public string ContentResourceTitle
		{
			get { return string.Empty; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return new List<IListItem>(); }
		}

		public string ContentProductsTitle
		{
			get { return string.Empty; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return new List<ProductStubItem>(); }
		}

		#endregion

		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get
			{
				if (!string.IsNullOrEmpty(BillNumber.Text)) return BillNumber.Text;
				if (!string.IsNullOrEmpty(BillTitle.Text)) return BillTitle.Text;

				return HeaderTitle;
			}
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