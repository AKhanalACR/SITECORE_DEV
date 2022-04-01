using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library;

namespace ACR.Library.RLI.Folders
{
	public partial class EventTagFolderItem : CustomItem
	{
		public static readonly string TemplateId = "{332D26BA-3D75-48C2-81DD-B4AD247331F4}";

		#region Boilerplate CustomItem Code

		public EventTagFolderItem(Item innerItem) : base(innerItem)
		{
		}

		public static implicit operator EventTagFolderItem(Item innerItem)
		{
			return innerItem != null ? new EventTagFolderItem(innerItem) : null;
		}

		public static implicit operator Item(EventTagFolderItem customItem)
		{
			return customItem != null ? customItem.InnerItem : null;
		}

		#endregion //Boilerplate CustomItem Code

		#region Field Instance Methods


		#endregion //Field Instance Methods
	}
}