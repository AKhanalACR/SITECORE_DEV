using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACRHelix.Website.sitecore.admin
{
  public partial class CTCApproval : System.Web.UI.Page
  {
        protected override void OnInit(EventArgs e)
        {
           // this.CheckSecurity(false);
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void GridView_CTC_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            if (e.CommandName == "Select")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                Button btnDelete = (Button)row.FindControl("btnDelete");
                btnDelete.Visible = true;
            }
        }


        private void CheckSecurity(bool isDeveloperAllowed)
        {
            if (Sitecore.Context.User.IsAdministrator || (isDeveloperAllowed && this.IsDeveloper)) return;
            var site = Sitecore.Context.Site;
            if (site != null)
            {
                base.Response.Redirect(string.Format("{0}?returnUrl={1}", site.LoginPage, HttpUtility.UrlEncode(base.Request.Url.PathAndQuery)));
            }
        }

        private bool IsDeveloper
        {
            get
            {
                return User.IsInRole(@"sitecore\developer") || User.IsInRole(@"sitecore\sitecore client developing");
            }
        }
    }
}