using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using ACR.Library.Utils;

namespace ACR.controls.MammographySavesLives.Homepage
{
	public partial class HomepagePrimaryVideoFeature : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Item item = Sitecore.Context.Item;

			if (item.Fields["Featured Video"].HasValue)
			{
				Item vid = ((InternalLinkField) (item.Fields["Featured Video"])).TargetItem;

				if(vid != null)
				{
					if (!string.IsNullOrEmpty(vid.Fields["Video ID"].Value))
					{
						SurvivorStoriesVideo.SetVideo(vid.Fields["Video ID"].Value);
					}
					else if (!string.IsNullOrEmpty(vid.Fields["Promo Teaser"].Value))
					{
						phTextBox.Visible = true;

						if (!string.IsNullOrEmpty(vid.Fields["Promo Title"].Value))
						{
							phTextBoxTitle.Visible = true;
							fldTeaserTitle.Item = vid;
						}
						
						litTeaser.Text = StringUtil.ReplacePTagsWithBrTags(vid.Fields["Promo Teaser"].Value);
					}

					//ribbon title
					imgHomepageFeatureVideoTitle.Item = vid;

					if (!string.IsNullOrEmpty(vid.Fields["Promo Link"].Value))
					{
						//ribbon arrow link
						videoArrowLink.HRef = videoTitleLink.HRef = ((LinkField)vid.Fields["Promo Link"]).Url;

						if (!string.IsNullOrEmpty(vid.Fields["Promo Link Title"].Value))
						{
							phLinkTitle.Visible = true;
							fldLinkTitle.Item = vid;
							ancAction.HRef = ((LinkField)vid.Fields["Promo Link"]).Url;
						}
					}	
				}
			}
		}
	}
}