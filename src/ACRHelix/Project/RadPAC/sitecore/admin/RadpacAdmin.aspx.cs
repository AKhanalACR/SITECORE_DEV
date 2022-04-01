using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACRHelix.Project.RadPAC.sitecore.admin
{
    public partial class RadpacAdmin : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            this.CheckSecurity();
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/App_Data/UploadFile/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);



                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        con.Open();
                        var src = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        var shName = src.Rows[0]["TABLE_NAME"].ToString().Trim(new Char[] { ' ', '\'' });

                        OleDbCommand cmd = new OleDbCommand("select * from [" + shName + "]", con); //"select * from [Sheet1$]"
                        DbDataReader dr = cmd.ExecuteReader();

                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["ACR_APP_DATA_Entities_2"].ConnectionString;

                        using (SqlConnection sqlConn = new SqlConnection(CS))
                        {
                            sqlConn.Open();
                            //Delete existing records
                            string deleteQuery = "TRUNCATE TABLE dbo.RadPAC_Contributors"; // "DELETE FROM dbo.RadPAC_Contributors";
                            SqlCommand sqlComm = new SqlCommand(deleteQuery, sqlConn);
                            sqlComm.ExecuteNonQuery();

                            // Bulk Copy to SQL Server   
                            SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                            bulkInsert.DestinationTableName = "RadPAC_Contributors";
                            try
                            {
                                bulkInsert.WriteToServer(dr);
                            }
                            catch (Exception x)
                            {
                                Sitecore.Diagnostics.Log.Info("--- RADPAC data upload 1 ---\n " + x.Message, this);
                                Sitecore.Diagnostics.Log.Info("--- RADPAC data upload 2 ---\n " + x.StackTrace, this);
                            }
                        }
                        BindGridview();
                        lblMessage.Text = "Your file uploaded successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Your data not uploaded";
                    Sitecore.Diagnostics.Log.Info("--- RADPAC data upload 3 ---\n " + ex.Message, this);
                    Sitecore.Diagnostics.Log.Info("--- RADPAC data upload 4 ---\n " + ex.StackTrace, this);
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void CheckSecurity()
        {
            if (Sitecore.Context.User.IsAdministrator || (this.IsInRole))
                return;

            var site = Sitecore.Context.Site;
            if (site != null)
            {
                base.Response.Redirect(string.Format("{0}?returnUrl={1}", site.LoginPage, HttpUtility.UrlEncode(base.Request.Url.PathAndQuery)));
            }
        }

        private bool IsInRole
        {
            get
            {
                return User.IsInRole(@"sitecore\ACR Editor") || User.IsInRole(@"sitecore\Sitecore Client Users");
            }
        }

        private void BindGridview()
        {
            string CS = ConfigurationManager.ConnectionStrings["ACR_APP_DATA_Entities_2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Get_RadPAC_Sample_Contribution_Data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

    }
}