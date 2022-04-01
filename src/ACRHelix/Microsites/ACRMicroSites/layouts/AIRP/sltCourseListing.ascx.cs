using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP.Pages;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.AIRP
{
	public partial class sltCourseListing : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			CategoricalCourseListingPageItem item = Sitecore.Context.Item;
			if (item == null)
			{
				return;
			}

			rptCourseListings.DataSource = item.InnerItem.Children;
			rptCourseListings.DataBind();
		}

		protected void rptCourseListings_OnItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			CategoricalCoursePageItem pageItem = new CategoricalCoursePageItem((Item) e.Item.DataItem);
			HyperLink hypCourseLink = (HyperLink) e.Item.FindControl("hypCourseLink");
			Image imgCourseThumbnail = (Image) e.Item.FindControl("imgCourseThumbnail");

			hypCourseLink.NavigateUrl = LinkUtils.GetItemUrl(pageItem);
			hypCourseLink.Text = TitleFactory.GetAIRPNavTitle(pageItem);
			if (pageItem.Icon != null && pageItem.Icon.MediaItem != null)
			{
				if (string.IsNullOrEmpty(Sitecore.Resources.Media.MediaManager.GetMediaUrl(pageItem.Icon.MediaItem)))
				{
					imgCourseThumbnail.Visible = false;
					return;
				}

				imgCourseThumbnail.ImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl((pageItem.Icon.MediaItem));
				imgCourseThumbnail.AlternateText = pageItem.Icon.MediaItem.Alt;
				imgCourseThumbnail.Attributes.Add("title", pageItem.Icon.MediaItem.Alt);
			}

            Literal date = (Literal)e.Item.FindControl("date");


            if (!String.IsNullOrEmpty(pageItem.ManualDate.Text.ToString()))
            {
                date.Text = pageItem.ManualDate.Text.ToString();
            }
            else
            {
                string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

                var starting = pageItem.StartDate.DateTime;
                var ending = pageItem.EndDate.DateTime;
                bool startingSet = starting != DateTime.MinValue; //MinValue is the DateTime default value.
                bool endingSet = ending != DateTime.MinValue;

                // No dates have been set (DateTime defaults to MinValue).
                if (!startingSet && !endingSet)
                {
                    date.Text = "";
                    return;
                }

                string timeframe = "";

                if (startingSet)
                {
                    timeframe += months[starting.Month - 1] + " " + starting.Day;
                }
                if (starting.Date != ending.Date)
                {
                    if ( !endingSet || ( startingSet && starting.Year != ending.Year))
                    {
                        timeframe += ", " + starting.Year;
                    }

                    if (startingSet && endingSet) timeframe += " - ";

                    if (endingSet)
                    {
                        if (starting.Month != ending.Month)
                        {
                            timeframe += months[ending.Month - 1] + " ";
                        }
                        timeframe += ending.Day;
                    }
                }

                if (endingSet) timeframe += ", " + ending.Year;

                date.Text = timeframe;
            }
		}
	}
}