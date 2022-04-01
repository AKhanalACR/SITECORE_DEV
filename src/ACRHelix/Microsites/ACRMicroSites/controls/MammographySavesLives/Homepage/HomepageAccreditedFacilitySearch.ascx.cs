using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.DataContexts;
using ACR.Library.MammographySavesLives.DataTemplates;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Common.Logging;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Velir.Utilities;

namespace ACR.controls.MammographySavesLives
{
	public partial class HomepageAccreditedFacilitySearch : System.Web.UI.UserControl
	{
		private const string MammographyModalityValue = "MAP";

		private static ILog _logger;
		private static ILog Logger
		{
			get
			{
				_logger = _logger ?? LogManager.GetLogger("HomepageAccreditedFacilitySearch");
				return _logger;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if(IsPostBack)
			{
				return;
			}

			_hasAccreditedFacilitySearchModuleItem accreditedFacilitySearchModuleItem = Sitecore.Context.Item;

				if (accreditedFacilitySearchModuleItem != null)
				{
					litModuleTitle.Text = accreditedFacilitySearchModuleItem.ModuleTitle.Rendered;
					litModuleText.Text = accreditedFacilitySearchModuleItem.ModuleText.Rendered;

					fldCalloutImage.Item = accreditedFacilitySearchModuleItem;
				}

				PopulateListsFromReferenceTables();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			if (ItemReference.MSL_FacilitySearch != null)
			{
				Hashtable options = new Hashtable();
				options.Add("loc", ACRLocality.SelectedValue);
				options.Add("cty", txtCity.Text.Trim());
				options.Add("zpc", txtZip.Text.Trim());
				string searchUrl = UrlUtil.CreateUrl(ItemReference.MSL_FacilitySearch.Url, options);
				Response.Redirect(searchUrl, true);
			}
		}

		private void PopulateListsFromReferenceTables()
		{
			Dictionary<string, string> localities;
			try
			{
                AcrAfwData dc = new AcrAfwData();
				//AcrAfwDataContext dc = new AcrAfwDataContext();
				localities = dc.GetLocalityEntities();
				//dc.Dispose();
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

		protected void cvZip_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (args.Value.Length == 0 || args.Value.Length >= 5)
			{
				args.IsValid = true;
			}
			else
			{
				args.IsValid = false;
			}
		}
	}
}