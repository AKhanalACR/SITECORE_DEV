using System;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.ImageWisely.Data;
using ACR.Library.Reference;
using Common.Logging;
using ACR.Library;

namespace ACR.layouts.ImageWisely
{
	public partial class sltTakeThePledge : System.Web.UI.UserControl
	{
		private static ILog _logger;

		private static ILog Logger
		{
			get
			{
				_logger = _logger ?? LogManager.GetLogger(typeof (sltTakeThePledge));
				return _logger;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (Sitecore.Context.Item.TemplateID.ToString() != HomePageItem.TemplateId)
			{
				return;
			}

			HomePageItem homeItem = Sitecore.Context.Item;

			ltlPledgeText.Text = homeItem.PledgeText.Text;

			//Pledges Made
			if (ItemReference.IW_Pledge_ImagingProfsPledgesMade.InnerItem != null)
			{
				try
				{
					PledgesMadeItem pledgesMadeItem = ItemReference.IW_Pledge_ImagingProfsPledgesMade.InnerItem;

                    // added by Addis on 12/02/2016
                    try
                    {
                        int countFromDb = DataHelper.GetPledgeCount();
                        if (pledgesMadeItem.PledgeCount.Integer != countFromDb)
                            ResetImagingProfessionalsPledgeCounter(countFromDb);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Could not reset \"Pledge Count\" field of the Pledges Made item.", ex);
                    }

					ltlPledgeCount.Text = pledgesMadeItem.PledgeCount.Integer.ToString("N0");
				}
				catch (Exception ex)
				{
					Logger.Error("Could not get Pledge count from \"Pledge Count\" field of the Pledges Made item.", ex);
					try
					{
						ltlPledgeCount.Text = DataHelper.GetPledgeCount().ToString("N0");
					}
					catch (Exception)
					{
						Logger.Error("Could not get Pledge count from external db, PledgeSubmissions table.", ex);
					}
				}
			}
		}

        /// <summary>
        /// Added on 12/02/2016 by Addis
        /// Resets "Pledges Made" and in master DB and then publishes item
        /// </summary>
        /// <returns></returns>
        private void ResetImagingProfessionalsPledgeCounter(int countFromDb)
        {
      //The web service, com.imagewisely.PledgesService, increments the "Pledges Made" 
      //field on the home node in the authoring environment and then publishes it back out
      //ACRMicroSites.com.imagewisely.PledgesService.PledgesService
      ACRMicroSites.com.imagewisely.PledgesService.PledgesService pledgesService = new ACRMicroSites.com.imagewisely.PledgesService.PledgesService();
            string sKey = AcrGlobals.WebServicesSecurityKey;
            if (sKey != "")
            {
                bool pledgesReset = pledgesService.ResetPledgeCounter(sKey, countFromDb);
                if (!pledgesReset)
                {
                    Logger.Error(
                        @"[Error] Take the Pledge: The field, ""Pledges Made,"" could not be reset. Check that the PledgesService web service is accessible on the authoring server. ");
                }
            }
            else
            {
                Logger.Error(
                    @"[Error] Take the Pledge: The field, ""Pledges Made"", could not be reset. Could not get the security key. ");
            }
        }

	}
}