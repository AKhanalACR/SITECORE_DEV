using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
	public partial class VendorItem : IListItem
	{
		public string LiTopic
		{
			get
			{
				return (!String.IsNullOrEmpty(InnerItem.Parent.DisplayName)) ? InnerItem.Parent.DisplayName : InnerItem.Parent.Name;
			}
		}

		public string LiTitle
		{
			get { return this.Organization.OrganizationName.Rendered; }
		}

		public string LiDescription
		{
			get { return this.Organization.OrganizationDescription.Rendered; }
		}

		public string LiUrl
		{
			get { return this.Organization.OrganizationUrl.Url; }
		}

		public string LiLinkTarget
		{
			get { return LinkUtils.GetLinkFieldTarget(this.Organization.OrganizationUrl.Field); }
		}

		public bool LiIsPdf
		{
			get { return LinkUtils.IsPdfLink(this.Organization.OrganizationUrl.Field); }
		}

		public string LiAssociatedPdfUrl
		{
			get { return String.Empty; }
		}

		public string LiType
		{
			get { return string.Empty; }
		}

		public DateTime LiDate
		{
			get {return DateTime.MinValue; }
		}

		public MediaItem LiImage
		{
			get { return this.Organization.Thumbnail.MediaItem; }
		}
	}
}
