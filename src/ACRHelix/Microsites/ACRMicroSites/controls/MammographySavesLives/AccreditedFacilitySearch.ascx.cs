using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.MammographySavesLives.PageTemplates;
using ACR.Library.Utils;
using Common.Logging;
using ACR.Library.DataContexts;
using ACR.Library.DataAccess;

namespace ACR.controls.MammographySavesLives
{
	public partial class AccreditedFacilitySearch : System.Web.UI.UserControl
	{
		private const string MammographyModalityValue = "MAP";
		private int counter = 0;
		private static ILog _logger;
		private static ILog Logger
		{
			get
			{
				_logger = _logger ?? LogManager.GetLogger("AccreditedFacilitySearch");
				return _logger;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			PopulateListsFromReferenceTables();

			if (Request.QueryString["loc"] != null || Request.QueryString["zpc"] != null || Request.QueryString["cty"] != null)
			{
				string locality = "00";
				string zip = "%";
				string city = "%";

				if (!string.IsNullOrEmpty(Request.QueryString["loc"]))
				{
					locality = Request.QueryString["loc"];
				}

				if (!string.IsNullOrEmpty(Request.QueryString["cty"]))
				{
					city = Request.QueryString["cty"];
					ACRCity.Text = city;
				}

				if (!string.IsNullOrEmpty(Request.QueryString["zpc"]))
				{
					zip = Request.QueryString["zpc"];
					ACRZipCode.Text = zip;
				}
				
				ListItem selectedListItem = ACRLocality.Items.FindByValue(locality);
				if (selectedListItem != null)
				{
					selectedListItem.Selected = true;
				}

				List<SqlParameter> paramsToPass = new List<SqlParameter>();
				paramsToPass.Add(new SqlParameter("@Modality", MammographyModalityValue));
				paramsToPass.Add(new SqlParameter("@Locality", locality));
				paramsToPass.Add(new SqlParameter("@City", city));
				paramsToPass.Add(new SqlParameter("@Zip", zip + "%"));
				RunSearch(paramsToPass);
			}
			else
			{
				pnlFacResults.Visible = false;
			}

			AccreditedFacilitySearchPageItem cItem = Sitecore.Context.Item;
			if (cItem != null)
			{
				litAdditionalInformation.Text = cItem.AdditionalInformation.Text;
			}
		}

        //public string DisplayImage(string txt)
        //{
        //    string bice = @"<img src=""/images/ACR/facility-search/bice_small.gif"" alt=""Breast Imaging Center of Excellence""/>";
        //    string pctap = @"<img src=""/images/ACR/facility-search/Image_Gently.jpg"" alt=""Pediatric CTAP Imaging facility""/>";

        //    if (txt == "1")
        //    {
        //        return bice;
        //    }
        //    if (txt == "2")
        //    {
        //        return pctap;
        //    }
        //    return "";
        //}

		private void PopulateListsFromReferenceTables()
		{
			Dictionary<string, string> localities;
			try
			{
                AcrAfwData dc = new AcrAfwData();
                //AcrAfwDataContext dc = new AcrAfwDataContext();
               
                    localities = dc.GetLocalityEntities();
                
			}
			catch (Exception exc)
			{
				Logger.Error("PopulateListsFromReferenceTables: error with the datacontext", exc);
				return;
			}

			ACRLocality.DataSource = localities;
			ACRLocality.DataTextField = "Value";
			ACRLocality.DataValueField = "Key";
			ACRLocality.DataBind();
		}


		private void RunSearch(List<SqlParameter> paramsToPass)
		{
			DataTable dt = new DataTable();

            try
            {
                try
                {
                    dt = AcrAfwDataAccess.ExecuteProcedure("client_ACR_spAFW_Get_msl", paramsToPass);
                }
                catch (Exception ex)
                {
                    dt = AcrAfwDataAccess.ExecuteProcedure("client_ACR_spAFW_Get", paramsToPass);
                }

				DataView firstView = new DataView(dt);
				firstView.RowFilter = "accred_status = 'a'";

				DataView secondView = new DataView(dt);
				secondView.RowFilter = "accred_status = 'u'";

				rptAccrFacilities.Visible = false;
				rptUnderReview.Visible = false;

				counter = 0;
				rptAccrFacilities.DataSource = firstView;
				rptAccrFacilities.DataBind();
				ltlCount1.Text = counter.ToString();
				if (counter > 0)
				{
					rptAccrFacilities.Visible = true;
				}

				//Set theCount Label
				counter = 0;
				rptUnderReview.DataSource = secondView;
				rptUnderReview.DataBind();
				ltlCount2.Text = counter.ToString();
				if (counter > 0)
				{
					rptUnderReview.Visible = true;
				}
			}
			catch (Exception exc)
			{
				Logger.Error("Error searching facilities:", exc);
				return;
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			List<SqlParameter> paramsToPass = new List<SqlParameter>();
			paramsToPass.Add(new SqlParameter("@Modality", MammographyModalityValue));
			paramsToPass.Add(new SqlParameter("@Locality", ACRLocality.SelectedItem.Value));
			paramsToPass.Add(new SqlParameter("@City", ACRCity.Text + "%"));
			paramsToPass.Add(new SqlParameter("@Zip", ACRZipCode.Text + "%"));

			RunSearch(paramsToPass);
			pnlFacResults.Visible = true;
		}

        protected void rptFacilities_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item == null || e.Item.DataItem == null)
            {
                return;
            }

            DataRowView row = e.Item.DataItem as DataRowView;
            if (row == null)
            {
                return;
            }

            Literal ltlFacName = e.Item.FindControl("ltlFacName") as Literal;
            Literal ltlFacAddr = e.Item.FindControl("ltlFacAddr") as Literal;
            Literal ltlFacCityStZip = e.Item.FindControl("ltlFacCityStZip") as Literal;
            Literal ltlFacPhone = e.Item.FindControl("ltlFacPhone") as Literal;
            Literal ltlExpDate = e.Item.FindControl("ltlExpDate") as Literal;
            Literal ltlBicoe = e.Item.FindControl("ltlBicoe") as Literal;
            Literal ltlImgGently = e.Item.FindControl("ltlImgGently") as Literal;
            Literal ltlCtLung = e.Item.FindControl("ltlCtLung") as Literal;
            Literal ltlDicoe = e.Item.FindControl("ltlDicoe") as Literal;


            ltlFacName.Text = row["organization_name"].ToString();
            ltlFacAddr.Text = row["street_address"].ToString();
            ltlFacCityStZip.Text = String.Format("{0}, {1} {2}", row["city"], row["State"], row["Zip"]);
            ltlFacPhone.Text = row["phone"].ToString();
            ltlExpDate.Text = String.IsNullOrEmpty(row["exp_date"].ToString()) ? "NA" : row["exp_date"].ToString();
            ltlBicoe.Text = DisplayImage(row["mammo_flag"].ToString(), 1);
            ltlImgGently.Text = DisplayImage(row["mammo_flag"].ToString(), 2);
            ltlCtLung.Text = DisplayImage(row["mammo_flag"].ToString(), 4);
            ltlDicoe.Text = DisplayImage(row["mammo_flag"].ToString(), 8);

            //row["modules"]
            //Takes the modules, split on each space, and replace all dashes with a space
            IEnumerable<string> modules = row["modules"].ToString().Split(' ').ToList().Select(s => s.Replace('-', ' '));

            Repeater rptModules = e.Item.FindControl("rptModules") as Repeater;
            rptModules.DataSource = modules;
            rptModules.DataBind();

            counter++;

        }
        public string DisplayImage(string txt, int bitVal)
        {
            string bice = @"<img src=""/images/ACR/facility-search/bice_small.gif"" alt=""Breast Imaging Center of Excellence""/>";
            string pctap = @"<img src=""/images/ACR/facility-search/Image_Gently.jpg"" alt=""Pediatric CTAP Imaging facility""/>";
            string ctlung = @"<img src=""/images/ACR/facility-search/Lung_Cancer_seal_small2.jpg"" alt=""Lung Cancer Screening Center""/>";
            string dice = @"<img src=""/images/ACR/facility-search/DICOE Logo_4c_small.jpg"" alt=""Diagnostic Imaging Center Of Excellence""/>";
            string returnImagesStr = "";
            int flag = Convert.ToInt32(txt);

            if ((flag & bitVal) > 0)
            {
                switch (bitVal)
                {
                    case 1: returnImagesStr += bice; break;
                    case 2: returnImagesStr += "&nbsp;&nbsp;&nbsp;" + pctap; break;
                    case 4: returnImagesStr += ctlung; break;
                    case 8: returnImagesStr += "&nbsp;&nbsp;&nbsp;" + dice; break;
                }
            }

            //  if ((flag & 4) > 0)
            //  {
            //      returnImagesStr +=  ctlung;
            //  }

            //  if ((flag & 2) >0)
            //{
            //    returnImagesStr += "&nbsp;&nbsp;&nbsp;" + pctap;
            //}


            //  if ((flag & 8) >0)
            //  {
            //      returnImagesStr += "&nbsp;&nbsp;&nbsp;" + dice;
            //  }

            return returnImagesStr;
        }

        //protected void rptFacilities_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item == null || e.Item.DataItem == null)
        //    {
        //        return;
        //    }

        //    DataRowView row = e.Item.DataItem as DataRowView;
        //    if (row == null)
        //    {
        //        return;
        //    }

        //    Literal ltlFacName = e.Item.FindControl("ltlFacName") as Literal;
        //    Literal ltlFacAddr = e.Item.FindControl("ltlFacAddr") as Literal;
        //    Literal ltlFacCityStZip = e.Item.FindControl("ltlFacCityStZip") as Literal;
        //    Literal ltlFacPhone = e.Item.FindControl("ltlFacPhone") as Literal;
        //    Literal ltlExpDate = e.Item.FindControl("ltlExpDate") as Literal;
        //    Literal ltlImageCell = e.Item.FindControl("ltlImageCell") as Literal;

        //    ltlFacName.Text = row["organization_name"].ToString();
        //    ltlFacAddr.Text = row["street_address"].ToString();
        //    ltlFacCityStZip.Text = String.Format("{0}, {1} {2}", row["city"], row["State"], row["Zip"]);
        //    ltlFacPhone.Text = row["phone"].ToString();
        //    ltlExpDate.Text = String.IsNullOrEmpty(row["exp_date"].ToString()) ? "NA" : row["exp_date"].ToString();
        //    ltlImageCell.Text = DisplayImage(row["mammo_flag"].ToString());

        //    IEnumerable<string> modules = row["modules"].ToString().Split(' ').ToList().Select(s => s.Replace('-', ' '));

        //    Repeater rptModules = e.Item.FindControl("rptModules") as Repeater;
        //    rptModules.DataSource = modules;
        //    rptModules.DataBind();

        //    counter++;
        //}

		protected void rptModules_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			Literal litModule = e.Item.FindControl("litModule") as Literal;
			if (e.Item == null || e.Item.DataItem == null)
			{
				return;
			}

			litModule.Text = e.Item.DataItem.ToString();
		}
	}
}