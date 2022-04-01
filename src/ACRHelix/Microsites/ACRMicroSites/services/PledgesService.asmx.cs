using System;
using System.Web.Services;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data;

namespace ACR.services
{
    /// <summary>
    /// Summary description for PledgesService
    /// </summary>
    [WebService(Namespace = "http://www.imagewisely.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PledgesService : System.Web.Services.WebService
    {
        /// <summary>
        /// Increments "Pledges Made" in master DB and then publishes item
        /// </summary>
        /// <returns>action completed: true or false</returns>
        [WebMethod]
        public bool IncrementPledgeCounter(string skey)
        {
            if (skey == "46iwa67zig928t")
            {
                Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
								PledgesMadeItem pledgesMadeItem = masterDb.GetItem(new ID(ItemReference.IW_Pledge_ImagingProfsPledgesMade.Guid));
                if (pledgesMadeItem != null)
                {
                    int currentPledgeCount = pledgesMadeItem.PledgeCount.Integer;
                    using (new Sitecore.SecurityModel.SecurityDisabler())
                    {
                        pledgesMadeItem.InnerItem.Editing.BeginEdit();
                        pledgesMadeItem.InnerItem.Fields["Pledge Count"].Value = (currentPledgeCount + 1).ToString();
                        pledgesMadeItem.InnerItem.Editing.EndEdit();
                        // Publish the Item
                        SitecoreUtils.PublishItem(pledgesMadeItem);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Added on 12/02/2016
        /// Resets "Pledges Made" in master DB and then publishes item
        /// </summary>
        /// <returns>action completed: true or false</returns>
        [WebMethod]
        public bool ResetPledgeCounter(string skey, int countFromDb)
        {
            if (skey == "46iwa67zig928t")
            {
                Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
                PledgesMadeItem pledgesMadeItem = masterDb.GetItem(new ID(ItemReference.IW_Pledge_ImagingProfsPledgesMade.Guid));
                if (pledgesMadeItem != null)
                {
                    int currentPledgeCount = pledgesMadeItem.PledgeCount.Integer;
                    using (new Sitecore.SecurityModel.SecurityDisabler())
                    {
                        pledgesMadeItem.InnerItem.Editing.BeginEdit();
                        pledgesMadeItem.InnerItem.Fields["Pledge Count"].Value = (countFromDb).ToString();
                        pledgesMadeItem.InnerItem.Editing.EndEdit();
                        // Publish the Item
                        SitecoreUtils.PublishItem(pledgesMadeItem);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
