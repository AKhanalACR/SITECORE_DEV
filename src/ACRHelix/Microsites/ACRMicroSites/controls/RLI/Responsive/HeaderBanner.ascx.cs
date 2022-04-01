using System;
using System.Linq;
using System.Web.UI;
using ACR.Library.Reference;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using ACR.Library.RLI.Pages;
using Sitecore.StringExtensions;

namespace ACR.controls.RLI.Responsive
{
  using System;

  public partial class HeaderBanner : System.Web.UI.UserControl
  {
    private void Page_Load(object sender, EventArgs e)
    {
      Item headerBannerAd = ItemReference.RLI_Header_BannerAd.InnerItem;

      if (headerBannerAd != null)
      {
        string strAdvertisementText = headerBannerAd.Fields["Advertisement JavaScript"].ToString();
        bool advertisementJsNotExists = strAdvertisementText.IsNullOrEmpty();

        if (advertisementJsNotExists)
        {
          headerBannerPLC.Visible = false;
          ltRliHeaderBannerAd.Visible = false;
        }
        else
        {
          ltRliHeaderBannerAd.Text = strAdvertisementText;
        }
      }
      else
      {
        headerBannerPLC.Visible = false;
        ltRliHeaderBannerAd.Visible = false;
      }
    }
  }
}