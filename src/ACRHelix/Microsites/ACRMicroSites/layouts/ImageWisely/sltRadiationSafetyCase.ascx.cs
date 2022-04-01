using System;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Data;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Common.Logging;
using Sitecore.Data.Items;

namespace ACR.layouts.ImageWisely
{
    public partial class sltRadiationSafetyCase : System.Web.UI.UserControl
    {
        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(sltRadiationSafetyCase));
                return _logger;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Item image = Sitecore.Context.Database.GetItem("{5457629A-AF07-42D2-97D1-A56D04CC5DB9}");
            imgRadSafetyCase.Src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(image);

            //"http://" + Request.Url.Host + "/~/media/ImageWisely%20Images/safetycase%20thumbnail.png";
            /*
            if (SitecoreUtils.IsValid(HomePageItem.TemplateId, Sitecore.Context.Item))
            {
                //hlSubscribe.NavigateUrl = ((HomePageItem)Sitecore.Context.Item).RSSFeedLink.Url;
                return;
            }*/

            //HomePageItem homeItem = Sitecore.Context.Item;

            //ltlPledgeText.Text = homeItem.PledgeText.Text;

            ////Pledges Made
            //if (ItemReference.IW_Pledge_ImagingProfsPledgesMade.InnerItem != null)
            //{
            //	try
            //	{
            //		PledgesMadeItem pledgesMadeItem = ItemReference.IW_Pledge_ImagingProfsPledgesMade.InnerItem;
            //		ltlPledgeCount.Text = pledgesMadeItem.PledgeCount.Integer.ToString("N0");
            //	}
            //	catch (Exception ex)
            //	{
            //		Logger.Error("Could not get Pledge count from \"Pledge Count\" field of the Pledges Made item.", ex);
            //		try
            //		{
            //			ltlPledgeCount.Text = DataHelper.GetPledgeCount().ToString("N0");
            //		}
            //		catch (Exception)
            //		{
            //			Logger.Error("Could not get Pledge count from external db, PledgeSubmissions table.", ex);
            //		}
            //	}
            //}
        }
    }
}