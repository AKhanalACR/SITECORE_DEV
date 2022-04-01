using Sitecore.Data;
using Sitecore.Data.Items;
using System;

namespace ACRMicroSites.layouts.ACR.sublayouts.content
{
  public partial class AccreditationMammographySection : System.Web.UI.UserControl
  {
    private const string YoutubeFormat = "<iframe width=\"100%\" height=\"100%\" src=\"{0}\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>";
    protected void Page_Load(object sender, EventArgs e)
    {

      var item = GetDatasourceItem();
      if (item != null)
      {

        sectionTitle.Item =
          leftlogo.Item =
          leftLogoLink.Item = 
          leftImage.Item =
          leftImageLink.Item =
          leftText.Item =
          leftLink.Item =
          centerLogo.Item =
          centerLogoLink.Item =
          //centerLeftImage.Item =
          centerLeftText.Item =
          centerLeftLink.Item =
          //centerRightImage.Item =
        centerRightText.Item =
        centerRightLink.Item =
        rightTitle.Item =
        rightText.Item =
        bottomTitle.Item =
        bottomText.Item = item;

        if (item.Fields["Show Search"].Value != "1")
        {
          stateCitySearch.Visible = false;
        }


        sectionTitle.Field = "Section Title";
        leftlogo.Field = "Left Logo";
        leftLogoLink.Field = "Left Logo Link";
        leftImage.Field = "Left Image";
        leftImageLink.Field = "Left Image Link";
        leftText.Field = "Left Text";
        leftLink.Field = "Left Link";

        centerLogo.Field = "Center Logo";
        centerLogoLink.Field = "Center Logo Link";
        //centerLeftImage.Field = "Left C Image";
        string centerLeftVideoURL = item.Fields["Left C Video Link"].Value;

        centerLeftText.Field = "Left C Text";
        centerLeftLink.Field = "Left C Link";

        //centerRightImage.Field = "Right C Image";
        string centerRightVideoURL = item.Fields["Right C Video Link"].Value;

        centerRightText.Field = "Right C Text";
        centerRightLink.Field = "Right C Link";

        rightTitle.Field = "Top Title";
        rightText.Field = "Search Text";
        bottomTitle.Field = "{A4DFBD9C-42AE-47C9-A67F-E2EC1F83B162}";
        bottomText.Field = "Bottom Text";


        if (!string.IsNullOrWhiteSpace(centerLeftVideoURL))
        {
          centerLeftVideo.Text = string.Format(YoutubeFormat, centerLeftVideoURL);
        }
        if (!string.IsNullOrWhiteSpace(centerRightVideoURL))
        {
          centerRightVideo.Text = string.Format(YoutubeFormat, centerRightVideoURL);
        }

      }


    }

    private Item GetDatasourceItem()
    {
      var sublayout = this.Parent as Sitecore.Web.UI.WebControls.Sublayout;
      if (sublayout != null)
      {
        Guid dataSourceId;
        Sitecore.Data.Items.Item dataSource;
        if (Guid.TryParse(sublayout.DataSource, out dataSourceId))
        {
          dataSource = Sitecore.Context.Database.GetItem(new ID(dataSourceId));
        }
        else
        {
          dataSource = Sitecore.Context.Database.GetItem(sublayout.DataSource);
        }
        return dataSource;
        //TODO set any other FieldRenderers here
      }
      return null;
    }
  }
}