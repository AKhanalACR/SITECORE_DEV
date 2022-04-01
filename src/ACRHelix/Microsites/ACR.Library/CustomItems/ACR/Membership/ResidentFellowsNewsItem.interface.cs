using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Controls.ACR.Common.Content;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Sitecore.Links;

namespace ACR.Library.ACR.Membership
{
	public partial class ResidentFellowsNewsItem : INavigationItem, IListItem, IAcrContent
	{
		#region Implementation of INavigationItem

		public string NavShortTitle
		{
			get { return Title.Text; }
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


		#region Implementation of IAcrContent

		public string HeaderTitle
		{
			get { return "Resident & Fellows News"; }
		}

		public string ContentTitle
		{
			get { return Title.Text; }
		}

		public string ContentSubTitle
		{
			get { return Subtitle.Text; }
		}

		public DateTime ContentDate
		{
			get { return Date.DateTime; }
		}

		public string ContentAuthor
		{
			get { return Author.Text; }
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
				//for body text we will want to prepend the inline image.
				StringBuilder body = new StringBuilder();

				//create an image rich text content region to add to our layout
				ImageRichTextContentRegion newseContent = new ImageRichTextContentRegion();

				//add our content details
				newseContent.ContentImageAlt = (Image != null && Image.MediaItem != null) ? Image.MediaItem.Alt : string.Empty;
				newseContent.ContentImageUrl = (Image != null && Image.MediaItem != null) ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(Image.MediaItem) : string.Empty;
				newseContent.BodyText = BodyText.Text;

				//render our news content.
				newseContent.RenderControl(new HtmlTextWriter(new StringWriter(body)));

				//return our body text
				return body.ToString();
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

		#region IListItem

		public string LiTopic
		{
			get { return string.Empty; }
		}

		public string LiTitle
		{
			get { return Title.Text; }
		}

		public string LiDescription
		{
			get { return AdditionalInformation.Text; }
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
			get { return "Resident Meeting"; }
		}

		public DateTime LiDate
		{
			get { return Date.DateTime; }
		}

		public MediaItem LiImage
		{
			get { return null; }
		}

		#endregion
	}
}
