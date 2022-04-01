using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.Utils;
using ACR.Library.MammographySavesLives.DataTemplates;
using ACR.Library.Utils;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace ACR.controls.MammographySavesLives.Homepage
{
	public partial class HomepageSmallPromo : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasSmallPromoFeatureItem currentItem = Sitecore.Context.Item;

			if(!string.IsNullOrEmpty(currentItem.PromoTitle.Raw))
			{
				phPromoTitle.Visible = true;
				litPromoTitle.Text = currentItem.PromoTitle.Text;
			}

			if (!string.IsNullOrEmpty(currentItem.PromoTeaser.Raw))
			{
				phPromoTeaser.Visible = true;
				litPromoTeaser.Text = currentItem.PromoTeaser.Text;
			}

			if (!string.IsNullOrEmpty(currentItem.PromoImage.Raw))
			{
				phPromoImage.Visible = true;
			}

			if (!string.IsNullOrEmpty(currentItem.PromoLinkTitle.Raw))
			{
				phPromoLink.Visible = true;
				hlPromoLink.Text = currentItem.PromoLinkTitle.Text;
				hlPromoLink.NavigateUrl = LinkUtil.GetLinkFieldUrl(currentItem.PromoLink.Field);
			}

			if (!string.IsNullOrEmpty(currentItem.PromoLink2Title.Raw))
			{
				phPromoLink2.Visible = true;
				hlPromoLink2.Text = currentItem.PromoLink2Title.Text;
				hlPromoLink2.NavigateUrl = LinkUtil.GetLinkFieldUrl(currentItem.PromoLink2.Field);
			}

			if (!string.IsNullOrEmpty(currentItem.PromoLinkTitle.Raw) && !string.IsNullOrEmpty(currentItem.PromoLink2Title.Raw))
			{
				phPromoLinkLinkBreak.Visible = true;
			}
		}
	}
}