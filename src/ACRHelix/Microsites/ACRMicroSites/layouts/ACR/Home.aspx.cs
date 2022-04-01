using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            heroImage.Field = Types.Fields.HomeHeroImage;
            heroHeader.FieldName = Types.Fields.HomeHeroHeadline;
            heroContent.FieldName = Types.Fields.HomeHeroContent;


            string link = Sitecore.Context.Item[Types.Fields.HomeHeroLink];
            if (!string.IsNullOrWhiteSpace(link))
            {
                heroLink.Field = Types.Fields.HomeHeroLink;
                string linkText = Sitecore.Context.Item[Types.Fields.HeroLinkText];
                heroLink.Text = string.IsNullOrWhiteSpace(linkText) ? "Learn More" : linkText;
            }
            else
            {
                heroLink.Visible = false;
            }
            setBackgroundColorCssClass();
        }

        private void setBackgroundColorCssClass()
        {
            string color = "";
            string colorID = Sitecore.Context.Item[Types.Fields.HomeHeroBackgroundColor];
            Item backgroundColor = Sitecore.Context.Database.GetItem(colorID);
            if (backgroundColor != null)
            {
                color = backgroundColor.Fields[Types.Fields.HeroBackgroundColorCssClass].Value;
                if (!string.IsNullOrWhiteSpace(color))
                {
                    homeHero.Attributes.Add("class", color);
                }

            }

        }
    }
}