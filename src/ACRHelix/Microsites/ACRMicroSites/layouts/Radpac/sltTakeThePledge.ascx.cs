using System;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Radpac.Data;
using ACR.Library.Reference;
using Common.Logging;

namespace ACR.layouts.Radpac
{
    public partial class sltTakeThePledge : System.Web.UI.UserControl
    {
        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(sltTakeThePledge));
                return _logger;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Item.TemplateID.ToString() != HomePageItem.TemplateId)
                return;

            HomePageItem homeItem = Sitecore.Context.Item;

            ltlPledgeText.Text = homeItem.PledgeText.Text;

            //Pledges Made
            if (ItemReference.IW_Pledge_ImagingProfsPledgesMade.InnerItem != null)
            {
                try
                {
                    PledgesMadeItem pledgesMadeItem = ItemReference.IW_Pledge_ImagingProfsPledgesMade.InnerItem;
                    ltlPledgeCount.Text = pledgesMadeItem.PledgeCount.Integer.ToString();
                }
                catch (Exception ex)
                {
                    Logger.Error("Could not get Pledge count from \"Pledge Count\" field of the Pledges Made item.", ex);
                    try
                    {
                        ltlPledgeCount.Text = DataHelper.GetPledgeCount().ToString();
                    }
                    catch (Exception)
                    {
                        Logger.Error("Could not get Pledge count from external db, PledgeSubmissions table.", ex);
                    }
                }
            }
        }
    }
}