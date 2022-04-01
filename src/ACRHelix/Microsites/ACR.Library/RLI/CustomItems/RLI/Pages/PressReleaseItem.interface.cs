using System;
using ACR.Library.RLI.Interfaces;
using ACR.Library.Utils;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Pages
{
    public partial class PressReleaseItem : IFeatured
    {

	 //   public string CoveoTitle(string collectionName)
	 //   {
		//    return PageBase.Title.Text;
	 //   }

	 //   public string CoveoOverrideUrl(string collectionName)
	 //   {
		//    return LinkUtils.GetItemUrl(InnerItem);
	 //   }

	 //   public string CoveoDescription(string collectionName)
	 //   {
  //          return InternalPageBase.ShortDescription.Text;
	 //   }

	 //   public DateTime CoveoDate(string collectionName)
	 //   {
		//    return InnerItem.Statistics.Updated;
	 //   }

	 //   public DateTime CoveoCreatedDate(string collectionName)
	 //   {
		//    return InnerItem.Publishing.PublishDate;
	 //   }

	 //   public string CoveoDisplayDate(string collectionName)
	 //   {
		//    return CoveoDate(collectionName).ToString(AcrConstants.DateFormats.MonthDayYear);
	 //   }

	 //   public Dictionary<string, string> CoveoAdditionalFields(string collectionName)
		//{
		//	Dictionary<string, string> fields = new Dictionary<string, string>();
		//	fields.Add("Body", this.InternalPageBase.Body.Text);
		//	return fields;
	 //   }

	 //   public bool CoveoExcludeFromIndex(string collectionName)
	 //   {
		//    //only allow through general search collection crawlers
		//		return collectionName != SearchContext.RLICollectionName && !SearchContext.RLICollectionName.StartsWith(collectionName);
	 //   }

        #region Implementation of IFeatured
        public string FeaturedTitle
        {
            get { return PageBase.Title.Rendered; }
        }

        public string FeaturedSubheader
        {
            get { return String.Empty; }
        }

        public string FeaturedDescription
        {
            get { return InternalPageBase.ShortDescription.Rendered; }
        }

        public string FeaturedUrl
        {
            get { return LinkUtils.GetItemUrl(this); }
        }
        #endregion
    }
}