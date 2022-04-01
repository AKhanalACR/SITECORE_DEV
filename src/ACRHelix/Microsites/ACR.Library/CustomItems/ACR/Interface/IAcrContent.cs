using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface IAcrContent
	{
		string HeaderTitle { get; }
		bool ReplacePageTitleBannerWithHeaderImage { get; }
		string ContentTitle { get; }
		string ContentSubTitle { get; }
		DateTime ContentDate { get; }
		string ContentAuthor { get; }
		string ContentImageUrl { get; }
		string ContentBodyText { get; }
		string ContentAdditionalInformation { get; }

		string ContentResourceTitle { get; }
		IList<IListItem> ContentResourceLinks { get; }

		string ContentProductsTitle { get; }
		IList<ProductStubItem> ContentProducts { get; }
	}
}
