using System;
using System.Linq;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Folders
{
	public partial class EventTagFolderItem
	{
		public static List<EventTagItem> GetAllEventTags()
		{
			Item tagsFolder = ItemReference.RLI_EventTags.InnerItem;
			return tagsFolder.Axes.GetDescendants()
				.Where(i => i != null && SitecoreUtils.IsValid(EventTagItem.TemplateId, i))
				.Select(i => (EventTagItem)i)
				.ToList();
		}
	}
}