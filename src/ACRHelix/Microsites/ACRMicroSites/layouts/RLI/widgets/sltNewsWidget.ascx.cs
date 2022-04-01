using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.controls.RLI;
using ACR.Library.RLI.Pages;
using ACR.Library.RLI.Widgets;
using ACR.Library.Utils;

namespace ACR.layouts.RLI.widgets
{
    public partial class sltNewsWidget : RLIWidgetControl
    {
        private class PressReleaseYear
        {
            public int Year { get; set; }
            public string ID { get; set; }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //get our current item as a Latest News item
            LatestNewsItem widgetItem = WidgetItem;

            if (widgetItem == null)
            {
                Visible = false;
                return;
            }

            //icon
            if (widgetItem.Icon != null && widgetItem.Icon.MediaItem != null)
            {
                imgIcon.Initialize(widgetItem.Icon.MediaItem);
            }
            else
            {
                imgIcon.Visible = false;
            }

            //header
            ltlTitle.Text = widgetItem.Title.Rendered;

            int maxItems = widgetItem.NumberofStories.Integer;
            if (maxItems == 0) maxItems = 3;


            //RLIPressReleasesIndex prIndex = new RLIPressReleasesIndex();


            var pressreleases = GetPressReleasesForYear(DateTime.Now.Year).Take(maxItems).ToList();

            if (pressreleases.Count() < maxItems)
            {
                var lastYear = GetPressReleasesForYear(DateTime.Now.Year - 1).Take(maxItems - pressreleases.Count()).ToList();
                pressreleases.AddRange(lastYear);

            }
            pressreleases = pressreleases.OrderByDescending(x => x.DateValue).ToList();
            //prIndex.GetLatestPressReleases(maxItems);


            rptNews.DataSource = pressreleases;
            rptNews.DataBind();
        }

        private List<PressReleaseYear> GetPressReleaseYears()
        {
            List<PressReleaseYear> yearList = new List<PressReleaseYear>();
            var years = Sitecore.Context.Database.GetItem("{09FCBECB-DD8E-4713-B643-2098524A5C15}").GetChildren().Where(x => x.TemplateID.ToString() == "{85CA522E-84E3-4C87-AFCF-F60733AFB401}").ToList();
            //Sitecore.Context.Item
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

            if (yearFolder != null)
            {
                foreach (var pressItem in yearFolder.GetChildren().Where(x => x.TemplateID.ToString() == "{60C77E32-5028-4C5C-88B5-89CABABA6BAD}"))
                {
                    PressReleaseItem pri = new PressReleaseItem(pressItem);
                    items.Add(pri);

                }
            }
                


            return items;

        }

        protected void rptNews_DataBound(object sender, RepeaterItemEventArgs e)
        {
            PressReleaseItem prItem = e.Item.DataItem as PressReleaseItem;
            if (prItem == null)
            {
                return;
            }

            var hlNewsItem = (HyperLink)e.Item.FindControl("hlNewsItem");

            string url = LinkUtils.GetItemUrl(prItem);
            string title = prItem.PageBase.Title.Text.Trim();
            if (url != String.Empty && title != String.Empty)
            {
                hlNewsItem.Text = StringUtil.GetShortenString(title, 30);
                hlNewsItem.NavigateUrl = url;
            }
            else
            {
                hlNewsItem.Visible = false;
            }

        }
    }
}