using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.ImageWisely.Data;
using Microsoft.CSharp;


namespace ACR.controls.ImageWisely
{
	public partial class PledgeFacilitiesList : System.Web.UI.UserControl
	{
		private IList<Pledge> _facilityPledges;
		private bool _international = false;
 
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public void Initialize(IList<Pledge> facilityPledges, string level, bool activeTab = false)
		{
			_facilityPledges = facilityPledges;
			if (level.ToLower() == "international")
			{
				_international = true;
				rptStateOrCountry.DataSource = _facilityPledges.Select(p => p.Country).Distinct().OrderBy(p => p);
			}
			else
			{
				rptStateOrCountry.DataSource = _facilityPledges.Select(p => p.StateProvince).Distinct().OrderBy(p => p);	
			}


			rptStateOrCountry.DataBind();

			Literal litDivLevel = (Literal)rptStateOrCountry.Controls[0].Controls[0].FindControl("litDivLevel");
			litDivLevel.Text = string.Format("<div class=\"listWrap {0}{1}\">", level.ToLower() == "international" ? "international" : level.Replace(" ", "").ToLower(), activeTab ? " active" : "");

			Literal litLevelDescription = (Literal)rptStateOrCountry.Controls[0].Controls[0].FindControl("litLevelDescription");
			litLevelDescription.Text = string.Format("<h2>These facilities have <span>pledged</span> to <span>IMAGE WISELY</span></h2>");
		}

		protected void rptStateOrCountry_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Literal litStateOrCountry = (Literal)e.Item.FindControl("litStateOrCountry");
				Repeater rptFacility = (Repeater)e.Item.FindControl("rptFacility");

				string stateOrCountry = (string)e.Item.DataItem;

				if (stateOrCountry == null)
				{
					return;
				}

				litStateOrCountry.Text = stateOrCountry;

				if(_international)
				{

					rptFacility.DataSource = _facilityPledges.Where(p => p.Country.ToUpper() == stateOrCountry.ToUpper())
					                                         .Select(q => new { Country = q.Country, City = q.City.ToString().ToUpper() })
					                                         .Distinct().Select(p=>p)
					                                         .OrderBy(p => p.City );
				}
			
				else
				{
					rptFacility.DataSource = _facilityPledges.Where(p => p.StateProvince.ToUpper() == stateOrCountry.ToUpper())
					                                         .Select(q =>new {StateProvince= q.StateProvince,City= q.City.ToString ().ToUpper () })
					                                         .Distinct() .Select(p=>p)
					                                         .OrderBy(p => p.City );
				}

				if(rptFacility .DataSource  != null)
				{
					rptFacility.DataBind();
				}
			}
		}

		protected void rptFacility_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Literal litCity = (Literal)e.Item.FindControl("litCity");
				Repeater rptCity = (Repeater)e.Item.FindControl("rptCity");

				string city =(DataBinder.Eval(e.Item.DataItem, "City").ToString().ToUpper ());

				if (city == null)
				{
					return;
				}

				litCity.Text = city;

				// rptCity.DataBind();
				if (_international)
				{
					string country = (DataBinder.Eval(e.Item.DataItem, "Country").ToString());
					rptCity.DataSource = _facilityPledges.Where(p => p.Country == country && p.City.ToUpper() == city.ToUpper ()).Select(p => p).OrderBy(p => p.Institution ); 
				}
				else
				{
					string state = (DataBinder.Eval(e.Item.DataItem, "StateProvince").ToString()); 
					rptCity.DataSource = _facilityPledges.Where(p => p.StateProvince == state && p.City.ToUpper () == city.ToUpper ()).Select(p => p).OrderBy(p => p.Institution);
				}
				rptCity.DataBind();
			}
		}

		protected void rptCity_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				Literal litFacilityName = (Literal)e.Item.FindControl("litFacilityName");
				Literal litFacilityLocation = (Literal)e.Item.FindControl("litFacilityLocation");

				Pledge pledge = (Pledge)e.Item.DataItem;

				if (pledge == null)
				{
					return;
				}

				litFacilityName.Text =pledge.Institution;
				litFacilityLocation.Text = GetLocation(pledge);
			}
		}

		private string GetLocation(Pledge pledge)
		{
			string city = pledge.City;
			string stateOrCountry = pledge.StateProvince;
			if(_international)
			{
				stateOrCountry = pledge.Country;
			}
			string separator = string.Empty;


			if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(stateOrCountry))
			{
				separator = ", ";
			}

			return string.Format("{0}{1}{2}", city, separator, stateOrCountry);
		}
	}
}