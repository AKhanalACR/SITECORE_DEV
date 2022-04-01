using System;
using System.IO;
using System.Text;
using System.Web.UI;
using ACR.Library.ACR.Globals;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Controls.ACR.Common.Content;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using Velir.SitecoreLibrary.Extensions;

namespace ACR.Library.ACR.News
{
    public partial class NewsArticleItem : IListItem, IAcrContent, INavigationItem
    {
        #region IListItem

        public string LiTopic
        {
            get
            {
                if (ArticleType.Item != null
                    && BaseTemplateReference.IsValidTemplate(ArticleType.Item, EnumerationItem.TemplateId))
                {
                    EnumerationItem newsType = ArticleType.Item;
                    return string.Format("{0} News", newsType.GetName());
                }
                return "News";
            }
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
                //get our parent landing page, we will use that header title
                NewsCategoryListPageItem landingPage = InnerItem.GetAncestor(NewsCategoryListPageItem.TemplateId);

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


        //	#region ICoveoCrawlable

        //	public string CoveoTitle(string collectionName)
        //	{
        //		return StringUtil.GetNonEmptyString(Title.Text, Subtitle.Text, HeaderTitle);
        //	}

        //	public string CoveoOverrideUrl(string collectionName)
        //	{
        //		return string.Empty;
        //	}

        //	public string CoveoDescription(string collectionName)
        //	{
        //		return string.Empty;
        //	}

        //	public DateTime CoveoDate(string collectionName)
        //	{
        //		return Date.DateTime;
        //	}

        //	public DateTime CoveoCreatedDate(string collectionName)
        //	{
        //		return this.InnerItem.Statistics.Created;
        //	}

        //	public string CoveoDisplayDate(string collectionName)
        //	{
        //		return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
        //	}

        //	public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
        //	{
        //		var additionalFields = new Dictionary<string, string>();

        //		if (TaxonomyContent != null)
        //		{
        //			additionalFields.Add(CoveoFields.Modality.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedModalities));
        //			additionalFields.Add(CoveoFields.SubSpecialty.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedSubspecialites));
        //			additionalFields.Add(CoveoFields.Interest.FieldName, TaxonomyContent.GetTaxonomyForCoveo(TaxonomyContent.RelatedInterests));
        //		}

        //		additionalFields.Add(CoveoFields.ContentType.FieldName, "News Article");

        //		return additionalFields;
        //	}

        //	public bool CoveoExcludeFromIndex(string collectionName)
        //	{
        //		//only allow through general search collection crawlers
        //		return collectionName != SearchContext.ACRGeneralCollectionName && !SearchContext.ACRGeneralCollectionName.StartsWith(collectionName);
        //	}
        //
        //	#endregion
    }
}