using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Base;
using ACR.Library.CipService;
using ACR.Library.Utils;

namespace ACR.Library.ACR.Home
{
	public partial class ACRHomePageItem
	{
		private string _customWeight = "10";

		public ExportCaseData GetCaseInPoint()
		{
			return CaseInPointServiceHelper.GetCachedCaseInPoint();
		}

		#region ICoveoCrawlable

		public string CoveoTitle(string collectionName)
		{
			return StringUtil.GetNonEmptyString(BasePage.HeaderTitle.Text, BasePage.ShortTitle.Text, BasePage.PageTitle.Text, BasePage.Name);
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
			return InnerItem.Statistics.Updated;
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

			//additionalFields.Add(CoveoFields.CustomWeight.FieldName, _customWeight);
			//additionalFields.Add(CoveoFields.ContentType.FieldName, "Content Page");
			
			return additionalFields;
		}

		public bool CoveoExcludeFromIndex(string collectionName)
		{
			//only allow through general search collection crawlers
			//return collectionName != SearchContext.ACRGeneralCollectionName && !SearchContext.ACRGeneralCollectionName.StartsWith(collectionName);
            return false;
		}
	}
		#endregion
}
