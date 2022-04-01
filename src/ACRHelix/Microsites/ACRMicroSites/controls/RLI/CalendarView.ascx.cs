using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Folders;
using ACR.Library.Reference;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.controls.RLI
{
	public partial class CalendarView : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				return;
			}

			//populate Tags dropdown
			PopulateEventTagFilterDropDown();
		}

		private void PopulateEventTagFilterDropDown()
		{
			ddEventTags.Items.Add(new ListItem("- All Tags -", ""));

			foreach (EventTagItem tag in EventTagFolderItem.GetAllEventTags())
			{
				ddEventTags.Items.Add(new ListItem(tag.EventTagTitle.Text, tag.ID.ToShortID().ToString()));
			}

			if (!string.IsNullOrEmpty(Request.QueryString["f"]))
			{
				ddEventTags.SelectedValue = Request.QueryString["f"];
				HiddenField hiddenField = (HiddenField)Parent.FindControl("hdnFilterOptionId");
				hiddenField.Value = Request.QueryString["f"];
			}
		}
	}
}