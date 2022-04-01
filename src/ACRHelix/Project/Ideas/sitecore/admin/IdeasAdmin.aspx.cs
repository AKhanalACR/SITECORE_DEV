using System;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
 
namespace Ideas.Website.sitecore.admin
{
  public partial class IdeasAdmin : System.Web.UI.Page
  {
    //protected new void OnInit(EventArgs e)
    //{
    //  //this.CheckSecurity(false);
    //  base.OnInit(e);
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
  
    protected void lbInsert_Click(object sender, EventArgs e)
    {
      if (Page.IsValid)
      {
        // Create the user
      
      //SqlDataSource1.InsertParameters["ID"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtId")).Text;
      SqlDataSource1.InsertParameters["NAME"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtName")).Text;
         SqlDataSource1.InsertParameters["STREET"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtStreet")).Text;
      SqlDataSource1.InsertParameters["STREET2"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtStreet2")).Text;
      SqlDataSource1.InsertParameters["CITY"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtCity")).Text;
      SqlDataSource1.InsertParameters["STATE_ID"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtStateId")).Text;
      SqlDataSource1.InsertParameters["ZIP"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtZip")).Text;
      SqlDataSource1.InsertParameters["PHONE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtPhone")).Text;
      SqlDataSource1.InsertParameters["FAX"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtFax")).Text;
      SqlDataSource1.InsertParameters["EMAIL"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text;
      SqlDataSource1.InsertParameters["STATUS"].DefaultValue = "0";
        SqlDataSource1.InsertParameters["REGISTRATION_DATE"].DefaultValue = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");// ((TextBox)GridView1.FooterRow.FindControl("txtRegDate")).Text;
      SqlDataSource1.InsertParameters["LAST_UPDATE_DATE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtLastUpdateDate")).Text;
      SqlDataSource1.InsertParameters["PRACTICE_TYPE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtPracticeType")).Text; 
                     SqlDataSource1.InsertParameters["PHONE_EXT"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtPhoneExt")).Text;
      SqlDataSource1.InsertParameters["LAST_UPDATE_USER_ID"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtLastUpdatedUserid")).Text;
      SqlDataSource1.InsertParameters["IRB_APPROVAL_TYPE"].DefaultValue = ((DropDownList)GridView1.FooterRow.FindControl("DropDownListIrbApprovalType")).SelectedValue;
      SqlDataSource1.InsertParameters["IS_PARTICIPATING_SITE_APPROVAL_EXECUTED"].DefaultValue= ((CheckBox)GridView1.FooterRow.FindControl("CheckBoxIsApprovalExecuted")).Checked.ToString();    
      SqlDataSource1.InsertParameters["IS_IRB_APPROVED"].DefaultValue = ((CheckBox)GridView1.FooterRow.FindControl("CheckBoxIsIrbApproved")).Checked.ToString();
      SqlDataSource1.InsertParameters["IS_FACILITY_APPROVED"].DefaultValue = ((CheckBox)GridView1.FooterRow.FindControl("CheckBoxIsFacilityApproved")).Checked.ToString();
      SqlDataSource1.InsertParameters["IS_DEMENTIA_SPECIALIST_APPROVED"].DefaultValue = ((CheckBox)GridView1.FooterRow.FindControl("CheckBoxIsDemantiaSpecialistApproved")).Checked.ToString();
      SqlDataSource1.InsertParameters["CREATED_DATETIME"].DefaultValue = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") /*((TextBox)GridView1.FooterRow.FindControl("txtCreatedDate")).Text*/;
        SqlDataSource1.InsertParameters["CREATED_BY"].DefaultValue = "Admin Page User";           // Sitecore.Context.User.Profile.UserName.ToString();     /* ((TextBox)GridView1.FooterRow.FindControl("txtCreatedBy")).Text*/;
      SqlDataSource1.InsertParameters["LAST_MODIFIED_DATETIME"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtLastModifiedDate")).Text;
      SqlDataSource1.InsertParameters["LAST_MODIFIED_BY"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtLastModifiedBy")).Text;
      SqlDataSource1.InsertParameters["IS_ACTIVE"].DefaultValue = ((CheckBox)GridView1.FooterRow.FindControl("CheckBoxIsActive")).Checked.ToString();
      SqlDataSource1.InsertParameters["IS_DATA_COLLECTION_AVAILABLE"].DefaultValue = ((CheckBox)GridView1.FooterRow.FindControl("CheckBoxIsDataCollectionAvailable")).Checked.ToString();
      SqlDataSource1.InsertParameters["ORIGINAL_IRB_APPROVAL_DATE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtOriginalIrbApprovalDate")).Text;
      SqlDataSource1.InsertParameters["IRB_EXPIRATION_DATE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtIrbExpirationDate")).Text;
      SqlDataSource1.InsertParameters["SITE_ACTIVATION_DATE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtSiteActivationDate")).Text;
      SqlDataSource1.InsertParameters["SITE_WITHDRAWAL_DATE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtSiteWithdrawalDate")).Text;
      SqlDataSource1.InsertParameters["IS_TERMINATED"].DefaultValue = ((CheckBox)GridView1.FooterRow.FindControl("CheckBoxIsTerminated")).Checked.ToString();
      SqlDataSource1.InsertParameters["REASON_OF_TERMINATION"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtReasonofTermination")).Text;
      SqlDataSource1.InsertParameters["LATITUDE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtLatitude")).Text;
      SqlDataSource1.InsertParameters["LONGITUDE"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("txtLongitude")).Text;
      var success = SqlDataSource1.Insert();
        if (success > 0)
        {
          ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alertAddition();", true);
        }
      }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    //private void CheckSecurity(bool isDeveloperAllowed)
    //{
    //  if (Sitecore.Context.User.IsAdministrator || (isDeveloperAllowed && this.IsDeveloper)) return;
    //  var site = Sitecore.Context.Site;
    //  if (site != null)
    //  {
    //    base.Response.Redirect(string.Format("{0}?returnUrl={1}", site.LoginPage, HttpUtility.UrlEncode(base.Request.Url.PathAndQuery)));
    //  }
    //}

    //private bool IsDeveloper
    //{
    //  get
    //  {
    //    return User.IsInRole(@"sitecore\developer") || User.IsInRole(@"sitecore\sitecore client developing");
    //  }
    //}
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDeleted(Object sender, GridViewDeletedEventArgs e)
    {
      if (e.AffectedRows > 0)
      {      
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alertDelete();", true);
      }      
    }
    protected void GridView1_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
    {
      if (e.AffectedRows > 0)
      {
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alertUpdate();", true);
      }
    } 
  }
}

