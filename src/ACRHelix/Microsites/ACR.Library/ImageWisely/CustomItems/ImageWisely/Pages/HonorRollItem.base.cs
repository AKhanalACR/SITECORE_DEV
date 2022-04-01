using System;
using Sitecore.Data.Items;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
	public partial class HonorRollItem : CustomItem
	{
		public static readonly string TemplateId = "{76485F7A-E300-4C73-9943-7DAD07057EC6}";
		#region Inherited Base Templates

		private readonly PageSettingsItem _PageSettingsItem;
		public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
		private readonly MetadataItem _MetadataItem;
		public MetadataItem Metadata { get { return _MetadataItem; } }
		private readonly ContentPageItem _ContentPageItem;
		public ContentPageItem ContentPage { get { return _ContentPageItem; } }

		#endregion

		#region Boilerplate CustomItem Code

		public HonorRollItem(Item innerItem) : base(innerItem)
		{
			_PageSettingsItem = new PageSettingsItem(innerItem);
			_MetadataItem = new MetadataItem(innerItem);
			_ContentPageItem = new ContentPageItem(innerItem);

		}

		public static implicit operator HonorRollItem(Item innerItem)
		{
			return innerItem != null ? new HonorRollItem(innerItem) : null;
		}

		public static implicit operator Item(HonorRollItem customItem)
		{
			return customItem != null ? customItem.InnerItem : null;
		}

		#endregion //Boilerplate CustomItem Code


		#region Field Instance Methods

		#endregion //Field Instance Methods
	}
}
