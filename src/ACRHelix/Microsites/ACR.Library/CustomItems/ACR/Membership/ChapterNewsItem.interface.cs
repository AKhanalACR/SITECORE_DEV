using System;
using System.IO;
using System.Text;
using System.Web.UI;
using ACR.Library.ACR.Membership;
using ACR.Library.ACR.News;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Controls.ACR.Common.Content;
using ACR.Library.CustomItems.ACR.Interface;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using Velir.SitecoreLibrary.Extensions;

namespace ACR.Library.ACR.Membership
{
	public partial class ChapterNewsItem : IListItem, IAcrContent, INavigationItem
	{
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
			get { return string.Empty; }
		}

		public string LiUrl
		{
			get { return LinkManager.GetItemUrl(InnerItem); }
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
			get { return string.Empty; }
		}

		public DateTime LiDate
		{
			get { return Date.DateTime; }
		}

		public MediaItem LiImage
		{
			get { return Image.MediaItem; }
		}

		#endregion

		#region Implementation of IAcrContent

		public string HeaderTitle
		{
			get
			{
				//if we don't have any associated chapters then return empty string
				if (AssociatedChapter == null)
				{
					return string.Empty;
				}

				//we will want to use the title for our associated chapter
				//get our associated chapter
				Item chapter = AssociatedChapter.Item;

				//if we don't have a chapter return empty string
				if (chapter == null)
				{
					return string.Empty;
				}

				//get our chapter as an IAcrContent item
				IAcrContent content = ItemInterfaceFactory.GetItem<IAcrContent>(chapter);

				//if we don't have a content item then return empty string
				if (content == null)
				{
					return string.Empty;
				}

				//return our header title.
				return content.HeaderTitle;
			}
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
			get { return CopyrightStatement.Rendered; }
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
	}
}