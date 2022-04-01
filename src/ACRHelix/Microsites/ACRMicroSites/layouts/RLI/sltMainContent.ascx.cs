using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Interfaces;
using ACR.Library.Utils;

namespace ACR.layouts.RLI
{
    public partial class sltMainContent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }

            if (!SitecoreUtils.IsValid(PageBaseItem.TemplateId, Sitecore.Context.Item))
            {
                return;
            }

            if (SitecoreUtils.IsValid(EventBaseItem.TemplateId, Sitecore.Context.Item.Template))
            {
                EventBaseItem eventbase = Sitecore.Context.Item;
                ltlTitle.Text = eventbase.EventTitle;
            }
            else
            {
                PageBaseItem page = Sitecore.Context.Item;
                ltlTitle.Text = page.Title.Rendered;
            }
            
            
            
        }
    }
}