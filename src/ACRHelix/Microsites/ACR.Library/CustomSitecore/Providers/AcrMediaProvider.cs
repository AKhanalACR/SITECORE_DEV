using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace ACR.Library.CustomSitecore.Providers
{
	public class AcrMediaProvider : MediaProvider
	{
		public override string GetMediaUrl(MediaItem item, MediaUrlOptions options)
		{
			if (BaseTemplateReference.IsValidTemplate(Sitecore.Context.Item, PledgeFormItem.TemplateId))
			{
				options.AlwaysIncludeServerUrl = true;
			}

			return base.GetMediaUrl(item, options);
		}
	}
}