using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data ;
using System.Globalization;
using ACR.Library.ImageWisely.Data;

namespace ACR.layouts.ImageWisely
{
	public partial class sltHonorRoll : System.Web.UI.UserControl
	{
		public const string ImageWiselyHonorRollLabel = "Image Wisely Honor Roll";
		public const string InternationalLabel = "International";
		private IList<Pledge> _facilityPledgesUnitedStates;
		private IList<Pledge> _facilityPledgesInternational;

		protected void Page_Load(object sender, EventArgs e)
		{
			IList<Pledge> assocPledges = DataHelper.GetAssociationHonorRollPledges();
			IList<Pledge> facilityPledges = DataHelper.GetFacilityHonorRollPledges();

			liHonorRoll.InnerText = ImageWiselyHonorRollLabel;
			liInternational.InnerText = InternationalLabel;

			BindFacilities(facilityPledges);
			BindAssociations(assocPledges);
		}

		#region Private methods

		private void BindAssociations(IList<Pledge> lstAssociationPledgeSubmissions)
		{
			DataTable dtFacilities = ToDataSet(lstAssociationPledgeSubmissions).Tables[0];
			if (dtFacilities != null)
			{
				DataView view = new DataView(dtFacilities);

				view.Sort = "Institution" + " ASC";
			 
				grdPledgeHonorRollAssociation.DataSource = view;
				grdPledgeHonorRollAssociation.DataBind();
			}
		}

		private void BindFacilities(IList<Pledge> lstFacPledgeSubmissions)
		{
			if (lstFacPledgeSubmissions != null && lstFacPledgeSubmissions.Count > 0)
			{
				DateTime now = DateTime.Now;
				int currentYear = now.Year;
				_facilityPledgesUnitedStates = lstFacPledgeSubmissions.Where(f => f.Country.ToUpper() == "UNITED STATES" && f.TimeSubmitted <= now).Select(f => f).ToList();
				_facilityPledgesInternational = lstFacPledgeSubmissions.Where(f => f.Country != "UNITED STATES" && f.TimeSubmitted <= now).Select(f => f).ToList();

	//Date filtering
				{
					_facilityPledgesInternational =
						_facilityPledgesInternational.Where(
							x => (x.TimeSubmitted.Year == currentYear)).ToList();

					/* NOTE: The date handing for US pledges here here is designed to work over a change transition period.
					 * Before 1/1/2017; 1) list all pledged in the current calendar year 2) For US only: With all lvl 1&2&3 pledgers known
					 * On and After 1/1/17; List only the pledges in the currnet calendar year
					*/
					int transitionYear = 2017;
					if (currentYear < transitionYear)
					{
						_facilityPledgesUnitedStates =
							_facilityPledgesUnitedStates.Where(
								x => ((x.Level1 > 0) && (x.Level2 > 0) && (x.Level3 > 0)) || (x.TimeSubmitted.Year == currentYear)).ToList();
					}
					else
					{
						_facilityPledgesUnitedStates =
							_facilityPledgesUnitedStates.Where(
								x => (x.TimeSubmitted.Year == currentYear)).ToList();
					}
				}
				pflHonorRoll.Initialize(_facilityPledgesUnitedStates, ImageWiselyHonorRollLabel, true);
				pflInternational.Initialize(_facilityPledgesInternational, InternationalLabel);
			}
		}

		private DataSet ToDataSet<T>(IList<T> list)
		{

			Type elementType = typeof (T);
			DataSet ds = new DataSet();
			DataTable t = new DataTable();
			ds.Tables.Add(t);

			//add a column to table for each public property on T 
			foreach (var propInfo in elementType.GetProperties())
			{
				t.Columns.Add(propInfo.Name, propInfo.PropertyType);
			}
			string x = "";

			//go through each property on T and add each value to the table 
			foreach (T item in list)
			{
				DataRow row = t.NewRow();
				foreach (var propInfo in elementType.GetProperties())
				{
					row[propInfo.Name] = propInfo.GetValue(item, null);
				}

				if (row["Country"].ToString ().ToLower() != "united states")
					row["StateProvince"] = row["Country"];
				//This line was missing: 
				t.Rows.Add(row);
			}


			return ds;

		}

		#endregion

		protected void lstPledgeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnlAssociations.Visible = false;
			pnlFacilities.Visible = false;
			if (lstPledgeType.SelectedItem.Text.StartsWith("Associations", true, CultureInfo.InvariantCulture))
			{
				pnlAssociations.Visible = true;
			}
			else
			{
				pnlFacilities.Visible = true;
			}
		}

		public string GetStateStr(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return string.Empty;
			}
			string outstr = char.ToUpper(str[0]).ToString() + char.ToUpper(str[1]);
			return outstr;
		}

		public string UppercaseFirst(string s)
		{
			// Check for empty string.
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}

			string[] str = s.Split(' ');
			string outstr = "";
			foreach (string word in str)
			{
				outstr += char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ";
			}
			return outstr;
		}

	}
}