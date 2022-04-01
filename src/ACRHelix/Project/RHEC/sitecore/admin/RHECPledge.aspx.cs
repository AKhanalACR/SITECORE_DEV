using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;           
using System.Data.SqlClient;

namespace RHEC.Website.sitecore.admin
{
  public partial class RHECPledge : System.Web.UI.Page
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
      GridView1.Visible = true;
      GridView2.Visible = false;     

      Button_IPS.Enabled = false;     
      Button_FPS.Enabled = true;

      IndividualToExcel.Visible = true;
      FacilityToExcel.Visible = false;
      
      Label_Heading.Text = "Individual Pledge Submissions";
    }
    protected void Button_FPS_Click(object sender, EventArgs e)
    {
      GridView1.Visible = false;
      GridView2.Visible = true;    

      Button_IPS.Enabled = true;      
      Button_FPS.Enabled = false;

      IndividualToExcel.Visible = false;
      FacilityToExcel.Visible = true;

      Label_Heading.Text = "Facility Pledge Submissions";
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
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void SqlDataSource1_Selecting1(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void ExportIndividualToExcel(object sender, EventArgs e)
    {

      Response.Clear();
      Response.Buffer = true;
      string sFileName = "RHECIndividualPledge-" + System.DateTime.Now.Date + ".csv";
      sFileName = sFileName.Replace("/", "");
      Response.AddHeader("content-disposition",
       "attachment;filename=" + sFileName);
      Response.Charset = "";
      Response.ContentType = "application/text";

      GridView1.AllowPaging = false;
      GridView1.DataBind();

      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      for (int k = 0; k < GridView1.Columns.Count; k++)
      {
        //add separator
        sb.Append(GridView1.Columns[k].HeaderText + ',');
      }
      //append new line
      sb.Append("\r\n");
      for (int i = 0; i < GridView1.Rows.Count; i++)
      {
        for (int k = 0; k < GridView1.Columns.Count; k++)
        {
          //add separator
          sb.Append(GridView1.Rows[i].Cells[k].Text + ',');
        }
        //append new line
        sb.Append("\r\n");
      }
      Response.Output.Write(sb.ToString());
      Response.Flush();
      Response.End();
    }

    protected void ExportFacilityToExcel(object sender, EventArgs e)
    {


      Response.Clear();
      Response.Buffer = true;
      string sFileName = "RHECFacilityPledge-" + System.DateTime.Now.Date + ".csv";
      sFileName = sFileName.Replace("/", "");     
      Response.AddHeader("content-disposition",
       "attachment;filename="+ sFileName);
      Response.Charset = "";
      Response.ContentType = "application/text";

      GridView2.AllowPaging = false;
      GridView2.DataBind();

      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      for (int k = 0; k < GridView2.Columns.Count; k++)
      {
        //add separator
        sb.Append(GridView2.Columns[k].HeaderText + ',');
      }
      //append new line
      sb.Append("\r\n");
      for (int i = 0; i < GridView2.Rows.Count; i++)
      {
        for (int k = 0; k < GridView2.Columns.Count; k++)
        {
          //add separator
          sb.Append(GridView2.Rows[i].Cells[k].Text + ',');
        }
        //append new line
        sb.Append("\r\n");
      }
      Response.Output.Write(sb.ToString());
      Response.Flush();
      Response.End();
    }
  
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
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
  }
}