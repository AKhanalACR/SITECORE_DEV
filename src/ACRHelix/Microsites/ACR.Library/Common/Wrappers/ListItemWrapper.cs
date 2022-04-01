using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces;
using Sitecore.Data.Items;

namespace ACR.Library.Common.Wrappers
{
	public class ListItemWrapper : IListItem
	{
		public string LiTopic { get; set; }
		public string LiTitle { get; set; }
		public string LiDescription { get; set; }
		public string LiUrl { get; set; }
		public string LiLinkTarget { get; set; }
		public bool LiIsPdf { get; set; }
		public string LiAssociatedPdfUrl { get; set; }
		public string LiType { get; set; }
		public DateTime LiDate { get; set; }
		public MediaItem LiImage { get; set; }
	}
}
