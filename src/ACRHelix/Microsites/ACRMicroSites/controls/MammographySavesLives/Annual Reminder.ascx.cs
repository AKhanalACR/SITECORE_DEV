using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library;
using Common.Logging;
using ACRMicroSites.AnnualReminder;

namespace ACR.controls.MammographySavesLives 
{
	public partial class Annual_Reminder : System.Web.UI.UserControl 
	{
		private static ILog _logger;

		private static ILog Logger
		{
			get
			{
				if (_logger == null)
				{
					_logger = LogManager.GetLogger(typeof(Annual_Reminder));
				}
				return _logger;
			}
		}

		protected void Page_Load(object sender, EventArgs e) 
		{
		}

		protected void Page_Init(object sender, EventArgs e) 
		{
		    InitializeMonthsList();
        SetRequiredMarkers(Controls);	
		}

		protected void btnSubmit_Click(object sender, EventArgs e) 
		{
			//Get Web Form fields
			string name = Request.Form[txtName.UniqueID];
			Response.Write (name);
			
			string email = Request.Form[txtEmail.UniqueID];
			Response.Write (email);
			
			string zipcode = Request.Form[txtZipCode.UniqueID];
			Response.Write (zipcode);
			
			string month = Request.Form[lstMonth.UniqueID];
			Response.Write (month);
			
			if (Page.IsValid)
			{
				//The web service, com.imagewisely.PledgesService, increments the "Pledges Made" 
				//field on the home node in the authoring environment and then publishes it back out
				Logger.Debug("Adding Annual Reminder.");
        AnnualReminderService reminderService = new AnnualReminderService();
        string sKey = AcrGlobals.WebServicesSecurityKey;
        if (sKey != "")
        {
        	string errorMsg = reminderService.AddAnnualReminder(sKey, month, name, email, zipcode);

					if (!String.IsNullOrEmpty(errorMsg))
					{
						Logger.Error(errorMsg + ReminderDetailsForError(month, name, email, zipcode));
          }
        }
        else
        {
					Logger.Error(@"[Error] Annual_Reminder: The Annual Reminder could not " 
						+ @"be created. Could not get the security key. Reminder details: " 
						+ ReminderDetailsForError(month, name, email, zipcode));
        }

				Response.Redirect("/Confirmation.aspx");
			}
		
		}

		private string ReminderDetailsForError(string month, string name, string email, string zipcode)
		{
			return String.Format(" month= {0}, name= {1}, email= {2}, zip={3}", month, name, email, zipcode);
		}

		private void InitializeMonthsList() 
		{
			lstMonth.Items.Clear();
			DateTime firstMonth = Convert.ToDateTime("1/1/2000");
			int current = DateTime.Now.Month;
			for (int i = 0; i < 12; i++) {
				DateTime month = firstMonth.AddMonths(i);
				ListItem item = new ListItem();
				item.Text = month.ToString("MMMM");
				item.Value = month.ToString("MMMM");
				//item.Value = month.Month.ToString();
				if (month.Month == current) {
					item.Selected = true;
				}
				lstMonth.Items.Add(item);
			}
		}
		protected void IsTermsChecked(object source, ServerValidateEventArgs args) 
		{
			if (chkTerms.Checked)
				args.IsValid = true;
			else
				args.IsValid = false;
		}

		private void SetRequiredMarkers(ControlCollection controls) 
		{
			foreach (Control c in controls) {
				if (c is Label && (c as Label).CssClass.Contains("required")) {
					c.Controls.Add(Page.ParseControl((c as Label).Text + "<span>*</span>"));
				}
				SetRequiredMarkers(c.Controls);
			}
		}

	}
}
