using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Content
{
	public partial class ResourceLinkItem : IListItem
	{
		#region IListItem

		public string LiTopic
		{
			get { return string.Empty; }
		}

		public string LiTitle
		{
			get { return ResourceTitle.Text; }
		}

		public string LiDescription
		{
			get { return ResourceDescription.Text; }
		}

		public string LiUrl
		{
			get
			{
				if (Resource.Field.IsMediaLink)
				{
					return (Resource != null && Resource.Field.TargetItem != null) ? LinkUtils.GetLinkFieldUrl(Resource.Field) : string.Empty;
				}
				return Resource.Url;
			}
		}

		public string LiLinkTarget
		{
			get
			{
				return Resource.Field.IsInternal && !Resource.Field.IsMediaLink ? string.Empty : "_blank";
			}
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
			get { return DateTime.MinValue; }
		}

		public MediaItem LiImage
		{
			get { return ResourceIcon.MediaItem; }
		}

		#endregion
	}
}