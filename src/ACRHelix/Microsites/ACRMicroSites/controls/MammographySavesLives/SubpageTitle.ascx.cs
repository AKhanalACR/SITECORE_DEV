using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ACR.Library.CustomItems.MammographySavesLives.PageTemplates;
using ACR.Library.MammographySavesLives.PageTemplates;
using Sitecore.Data.Items;

namespace ACR.controls.MammographySavesLives
{
	public partial class SubpageTitle : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Item currentItem = Sitecore.Context.Item;

			if (currentItem != null && (currentItem.TemplateID.ToString() == ToolsAndResourcesPageItem.TemplateId || currentItem.TemplateID.ToString() == AccreditedFacilitySearchPageItem.TemplateId))
			{
				h1PageTitle.Attributes["class"] = "page-title-long";
			}
		}
	}
}