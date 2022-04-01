using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACRHelix.Project.ImageWisely.sitecore.admin
{
  public partial class IWPledge : System.Web.UI.Page
  {
    protected override void OnInit(EventArgs e)
    {
      this.CheckSecurity(false);
      base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      Label_Heading.Text = "Individual Pledge Submissions";
    }

    protected void Button_IPS_Click(object sender, EventArgs e)
    {
      GridView_IPS.Visible = true;
      GridView_FPS.Visible = false;
      GridView_RPPS.Visible = false;
      GridView_APS.Visible = false;

      Button_IPS.Enabled = false;
      Button_RPPS.Enabled = true;
      Button_FPS.Enabled = true;
      Button_APS.Enabled = true;

      Label_Heading.Text = "Individual Pledge Submissions";
    }

    protected void Button_RPPS_Click(object sender, EventArgs e)
    {
      GridView_IPS.Visible = false;
      GridView_FPS.Visible = false;
      GridView_RPPS.Visible = true;
      GridView_APS.Visible = false;

      Button_IPS.Enabled = true;
      Button_RPPS.Enabled = false;
      Button_FPS.Enabled = true;
      Button_APS.Enabled = true;

      Label_Heading.Text = "Referring Practitioner Pledge Submissions";

    }

    protected void Button_FPS_Click(object sender, EventArgs e)
    {
      GridView_IPS.Visible = false;
      GridView_FPS.Visible = true;
      GridView_RPPS.Visible = false;
      GridView_APS.Visible = false;

      Button_IPS.Enabled = true;
      Button_RPPS.Enabled = true;
      Button_FPS.Enabled = false;
      Button_APS.Enabled = true;

      Label_Heading.Text = "Facility Pledge Submissions";
    }

    protected void Button_APS_Click(object sender, EventArgs e)
    {
      GridView_IPS.Visible = false;
      GridView_FPS.Visible = false;
      GridView_RPPS.Visible = false;
      GridView_APS.Visible = true;

      Button_IPS.Enabled = true;
      Button_RPPS.Enabled = true;
      Button_FPS.Enabled = true;
      Button_APS.Enabled = false;

      Label_Heading.Text = "Association Pledge Submissions";
    }

    protected void GridView_IPS_RowCommand(object sender, GridViewCommandEventArgs e)
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

    protected void GridView_RPPS_RowCommand(object sender, GridViewCommandEventArgs e)
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

    protected void GridView_FPS_RowCommand(object sender, GridViewCommandEventArgs e)
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

    protected void GridView_APS_RowCommand(object sender, GridViewCommandEventArgs e)
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