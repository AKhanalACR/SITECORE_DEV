using System;
using System.Linq;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.Reference;
using ACR.Library.Search.Indices.Content;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.FAQ
{
	public partial class FAQItem : IListItem
{
	#region IListItem

	public string LiTopic
	{
		get { return string.Empty; }
	}

	public string LiTitle
	{
		get { return Question.Text; }
	}

	public string LiDescription
	{
		get { return String.Empty; }
	}

	public string LiUrl
	{
		get
		{
			String url = String.Empty;
			using (FAQListingIndex index = new FAQListingIndex())
			{
				FAQPageItem faqListing = index.GetFAQsByType(FAQType.Raw, 1).FirstOrDefault();
				if(faqListing != null)
				{
					url = LinkManager.GetItemUrl(faqListing.InnerItem) + "#" + DisplayName.Replace(" ", "_");
				}

			}
			return url;
		}
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
		get { return "FAQ"; }
	}

	public DateTime LiDate
	{
		get { return DateTime.MinValue; }
	}

	public MediaItem LiImage
	{
		get { return null; }
	}

	#endregion
}
}