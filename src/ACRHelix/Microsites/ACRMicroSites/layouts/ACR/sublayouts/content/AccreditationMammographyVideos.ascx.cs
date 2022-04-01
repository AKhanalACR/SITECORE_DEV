using Sitecore.Data;
using Sitecore.Data.Items;
using System;

namespace ACRMicroSites.layouts.ACR.sublayouts.content
{



  public partial class AccreditationMammographyVideos : System.Web.UI.UserControl
  {
    private const string YoutubeFormat = "<iframe width=\"100%\" height=\"100%\" src=\"{0}\" frameborder=\"0\" allow=\"autoplay; encrypted-media\" allowfullscreen></iframe>";

    protected void Page_Load(object sender, EventArgs e)
    {
      var item = GetDatasourceItem();
      if (item != null)
      {
        sectionTitle.Item = sectionSubTitle.Item = youtubeText1.Item = youtubeText2.Item = youtubeText3.Item = youtubeText4.Item = link1.Item = link2.Item = link3.Item = link4.Item = item;

        youtubeText1.Field = "{B5595E03-A4B2-4291-8983-08F15524F0B6}";
        youtubeText2.Field = "{50578A02-E8C9-4A52-8161-40153842D219}";
        youtubeText3.Field = "{A585D88E-A13B-452B-BBD3-8B6DCC7A7324}";
        youtubeText4.Field = "{23F368FE-4837-4163-B3C7-2798E5DBE2D3}";

        link1.Field = "{C31C6C63-B165-4D53-B58B-84F5ED464EB7}";
        link2.Field = "{C1BF179F-2AA9-489C-B518-4E3305D69641}";
        link3.Field = "{565CA2B9-C7F8-4BFB-AA8B-17E3CF89A0FD}";
        link4.Field = "{1F617393-7A2C-454E-BC2B-D7B5508917D0}";
        
        sectionTitle.Field = "{4287DE2F-BA60-4766-815E-5196327C9E41}";
        sectionSubTitle.Field = "Section Subtitle";

        string youtubeUrl1 = item.Fields["{CA2EA21B-F3C6-4632-B6F4-8728CFDA7734}"].Value;
        string youtubeUrl2 = item.Fields["{740C7D90-31A4-45BB-BECA-BA41F75E3C50}"].Value;
        string youtubeUrl3 = item.Fields["{40979231-AE6C-4D62-A0C8-BA8BBE75FB2E}"].Value;
        string youtubeUrl4 = item.Fields["{1BA2319B-18CF-47D1-9B6B-5EA3DA49AA9E}"].Value;

        if (!string.IsNullOrWhiteSpace(youtubeUrl1))
        {
          youtubeOne.Text = string.Format(YoutubeFormat, youtubeUrl1);
        }
        if (!string.IsNullOrWhiteSpace(youtubeUrl2))
        {
          youtubeTwo.Text = string.Format(YoutubeFormat, youtubeUrl2);
        }
        if (!string.IsNullOrWhiteSpace(youtubeUrl3))
        {
          youtubeThree.Text = string.Format(YoutubeFormat, youtubeUrl3);
        }
        if (!string.IsNullOrWhiteSpace(youtubeUrl4))
        {
          youtubeFour.Text = string.Format(YoutubeFormat, youtubeUrl4);
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