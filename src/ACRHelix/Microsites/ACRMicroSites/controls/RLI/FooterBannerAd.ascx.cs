using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACRMicroSites.controls.RLI
{
  public partial class FooterBannerAd : System.Web.UI.UserControl
  {

    private void Page_Load(object sender, EventArgs e)
    {
      Item footerBannerAd = Sitecore.Context.Database.GetItem("{8D725718-CFB5-4CE7-903F-97DF9704C02C}");

      if (footerBannerAd != null)
      {
        string strAdvertisementText = footerBannerAd.Fields["Advertisement JavaScript"].ToString();
        bool advertisementJsNotExists = string.IsNullOrWhiteSpace(strAdvertisementText);

        if (advertisementJsNotExists)
        {
          hdRlifooterBannerAd.Visible = false;
          ltRlifooterBannerAd.Visible = false;
        }
        else
        {
          ltRlifooterBannerAd.Text = strAdvertisementText;
        }
      }
      else
      {
        hdRlifooterBannerAd.Visible = false;
        ltRlifooterBannerAd.Visible = false;
      }
    }
  }
}