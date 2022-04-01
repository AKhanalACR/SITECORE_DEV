using System;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.Common.Interfaces
{
	[FactoryInterface]
	public interface IListItem
	{
		String LiTopic { get; }
		String LiTitle { get; }
		String LiDescription { get; }
		String LiUrl { get; }
		String LiLinkTarget { get; }
		Boolean LiIsPdf { get; }
		String LiAssociatedPdfUrl { get; }
		String LiType { get; }
		DateTime LiDate { get; }
		Sitecore.Data.Items.MediaItem LiImage { get; }
	}
}
