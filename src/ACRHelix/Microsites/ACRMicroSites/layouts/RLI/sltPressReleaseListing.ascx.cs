using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Text;
using SortDirection = System.Web.UI.WebControls.SortDirection;

namespace ACR.layouts.RLI
{




    public partial class sltPressReleaseListing : System.Web.UI.UserControl
    {
        private class PressReleaseYear
        {
            public int Year { get; set; }
            public string ID { get; set; }

        }

        private int CurrentYear
        {
            get
            {
                //get our raw url so we can pull out our current year
                UrlString rawUrl = new UrlString(Request.RawUrl);

                //get our current year
                int currentYear = DateTime.Now.Year;
                if (!int.TryParse(rawUrl["year"], out currentYear))
                {
                    return int.Parse(ddlPressReleaseYear.Items[0].Value);
                }

                //set our current year
                return currentYear;
            }
        }

        private List<PressReleaseYear> GetPressReleaseYears()
        {
            List<PressReleaseYear> yearList = new List<PressReleaseYear>();
            var years = Sitecore.Context.Item.GetChildren().Where(x => x.TemplateID.ToString() == "{85CA522E-84E3-4C87-AFCF-F60733AFB401}").ToList();
            foreach (var year in years)
            {
                PressReleaseYear y = new PressReleaseYear()
                {
                    Year = Convert.ToInt32(year.Name),
                    ID = year.ID.ToString()
                };
                yearList.Add(y);


            }
            return yearList;
        }




        protected void Page_Load(object sender, EventArgs e)
        {


            PressReleaseListingItem item = Sitecore.Context.Item;
            if (item == null)
            {
                return;
            }

            litBody.Text = item.Body.Text;
            //RLIPressReleasesIndex index = new RLIPressReleasesIndex();
            if (!IsPostBack)
            {
                List<PressReleaseYear> years = GetPressReleaseYears();

                //var years = Sitecore.Context.Item.GetChildren().Where(x => x.TemplateID.ToString() == "{85CA522E-84E3-4C87-AFCF-F60733AFB401}").ToList();
                //List<int> years = index.GetPressReleaseYears();
                if (years.Count == 0)
                {
                    return;
                }
                //ddlPressReleaseYear.DataSource = years;
                //ddlPressReleaseYear.DataValueField = years[0].i
                //ddlPressReleaseYear.DataTextField = "Name";             
                //ddlPressReleaseYear.SelectedIndex = 0;
                foreach (var y in years)
                {
                    ddlPressReleaseYear.Items.Add(new ListItem(y.Year.ToString()));
                }
                ddlPressReleaseYear.SelectedValue = CurrentYear.ToString();
            }
            rptPressReleases.DataSource = GetPressReleasesForYear(CurrentYear);
            rptPressReleases.DataBind();
        }

        private List<PressReleaseItem> GetPressReleasesForYear(int year)
        {
            List<PressReleaseItem> items = new List<PressReleaseItem>();
            string ID = string.Empty;

            List<PressReleaseYear> years = GetPressReleaseYears();
            foreach (var y in years)
            {

                if (year == y.Year)
                {
                    ID = y.ID;
                    break;
                }
            }



            var yearFolder = Sitecore.Context.Database.GetItem(ID);
            if(yearFolder != null)
            {
                foreach (var pressItem in yearFolder.GetChildren().Where(x => x.TemplateID.ToString() == "{60C77E32-5028-4C5C-88B5-89CABABA6BAD}"))
                {
                    PressReleaseItem pri = new PressReleaseItem(pressItem);
                    items.Add(pri);

                }
            }
            

            items = items.OrderByDescending(x => x.DateValue).ToList();

            return items;

        }



        protected void rptPressReleases_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            PressReleaseItem item = (PressReleaseItem)e.Item.DataItem;

            Literal litDate = (Literal)e.Item.FindControl("litDate");
            HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");

            litDate.Text = string.Format("{0: MMMM d, yyyy}", item.Date.DateTime);
            hlTitle.Text = item.PageBase.Title.Text;
            hlTitle.NavigateUrl = LinkUtils.GetItemUrl(item);
        }

        protected void ddlPressReleaseYear_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //get our selected year
            string selectedYear = ddlPressReleaseYear.SelectedValue;


            //get our current url string so we can add our year query param
            UrlString rawUrl = new UrlString(Request.RawUrl);

            //set our year url param to the selected value
            rawUrl["year"] = selectedYear;


            //redirect our user to the new url
            Response.Redirect(rawUrl.GetUrl(), true);
        }


    }
}