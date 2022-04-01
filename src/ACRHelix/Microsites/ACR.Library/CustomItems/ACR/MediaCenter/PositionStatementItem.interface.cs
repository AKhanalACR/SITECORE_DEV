using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Controls.ACR.Common.Content;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomSitecore.Extensions;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Velir.SitecoreLibrary.Extensions;

namespace ACR.Library.ACR.MediaCenter
{
	public partial class PositionStatementItem : IListItem, IAcrContent
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
			get { return string.Empty; }
		}

		public string LiUrl
		{
			get { return InnerItem.GetItemUrl(); }
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
			get
			{
				//if we don't have a date then return the min datetime
				if (Date == null)
				{
					return DateTime.MinValue;
				}

				//return our date
				return Date.DateTime;
			}
		}

		public MediaItem LiImage
		{
			get
			{
				//if we don't have an image then return null
				if (Image == null)
				{
					return null;
				}

				//return our image media item
				return Image.MediaItem;
			}
		}

		#endregion

		#region IAcrContent

		public string HeaderTitle
		{
			get
			{
				//get our parent landing page, we will use that header title
				PositionStatementsLandingPageItem landingPage = InnerItem.GetAncestor(PositionStatementsLandingPageItem.TemplateId);

				//if our landing page is null return an empty string
				if (landingPage == null)
				{
					return string.Empty;
				}

				//get our landing page as an IAcrContent object
				IAcrContent landingContent = ItemInterfaceFactory.GetItem<IAcrContent>(landingPage);

				//if we don't have landing content then return empty string
				if (landingContent == null)
				{
					return string.Empty;
				}

				//return our landing pages header title
				return landingContent.HeaderTitle;
			}
		}

		public string ContentTitle
		{
			get
			{
				//if we don't have a title then return the base title
				if (Title == null || string.IsNullOrEmpty(Title.Text))
				{
					return BaseContent.ContentTitle;
				}

				//return our title
				return Title.Text;
			}
		}

		public string ContentSubTitle
		{
			get
			{
				//if we don't have a subtitle then return the base subtitle
				if (Subtitle == null || string.IsNullOrEmpty(Subtitle.Text))
				{
					return BaseContent.ContentSubTitle;
				}

				//return our subtitle
				return Subtitle.Text;
			}
		}

		public DateTime ContentDate
		{
			get
			{
				//if we don't have a date then return min value
				if (Date == null)
				{
					return DateTime.MinValue;
				}

				//return our date
				return Date.DateTime;
			}
		}

		public string ContentAuthor
		{
			get
			{
				//if we don't have an author then return empty string
				if (Author == null)
				{
					return string.Empty;
				}

				//return our author
				return Author.Text;
			}
		}

		public string ContentImageUrl
		{
			get
			{
				//return our base content image
				return BaseContent.ContentImageUrl;
			}
		}

		public bool ReplacePageTitleBannerWithHeaderImage
		{
			get
			{
				return BaseContent.ReplacePageTitleBannerWithHeaderImage;
			}
		}

		public string ContentBodyText
		{
			get
			{
				//for body text we will want to prepend various elements
				//to our biography
				StringBuilder body = new StringBuilder();

				//create an image rich text content region to add to our layout
				ImageRichTextContentRegion articleContent = new ImageRichTextContentRegion();

				//add our content details
				articleContent.ContentImageAlt = (Image != null && Image.MediaItem != null) ? Image.MediaItem.Alt : string.Empty;
				articleContent.ContentImageUrl = (Image != null && Image.MediaItem != null) ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(Image.MediaItem) : string.Empty;
				articleContent.BodyText = BaseContent.ContentBodyText;

				//render our article content.
				articleContent.RenderControl(new HtmlTextWriter(new StringWriter(body)));

				//return our body text
				return body.ToString();
			}
		}

		public string ContentAdditionalInformation
		{
			get
			{
				//if we don't have additional information then return the base additional info
				if (AdditionalInformation == null || string.IsNullOrEmpty(AdditionalInformation.Text))
				{
					return BaseContent.ContentAdditionalInformation;
				}

				//return our additional information
				return AdditionalInformation.Text;
			}
		}

		public string ContentResourceTitle
		{
			get { return BaseContent.ContentResourceTitle; }
		}

		public IList<IListItem> ContentResourceLinks
		{
			get { return BaseContent.ContentResourceLinks; }
		}

		public string ContentProductsTitle
		{
			get { return BaseContent.ContentProductsTitle; }
		}

		public IList<ProductStubItem> ContentProducts
		{
			get { return BaseContent.ContentProducts; }
		}

		#endregion

		#region ICoveoCrawlable
        /*

		public string CoveoTitle(string collectionName)
		{
			return StringUtil.GetNonEmptyString(Title.Text, Subtitle.Text, HeaderTitle);
		}

		public string CoveoOverrideUrl(string collectionName)
		{
			return string.Empty;
		}

		public string CoveoDescription(string collectionName)
		{
			return string.Empty;
		}

		public DateTime CoveoDate(string collectionName)
		{
			return Date.DateTime;
		}

		public DateTime CoveoCreatedDate(string collectionName)
		{
			return this.InnerItem.Publishing.PublishDate;
		}

		public string CoveoDisplayDate(string collectionName)
		{
			return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
		}

		public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		{
			var additionalFields = new Dictionary<string, string>();

			additionalFields.Add(CoveoFields.ContentType.FieldName, "Position Statement");
			
			return additionalFields;
		}

		public bool CoveoExcludeFromIndex(string collectionName)
		{
			//only allow through general search collection crawlers
			return collectionName != SearchContext.ACRGeneralCollectionName && !SearchContext.ACRGeneralCollectionName.StartsWith(collectionName);
		}
        */
		#endregion
	}
}