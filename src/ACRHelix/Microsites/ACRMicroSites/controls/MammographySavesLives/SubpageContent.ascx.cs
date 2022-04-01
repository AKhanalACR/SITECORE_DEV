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
using Sitecore.Data.Items;

namespace ACR.controls.MammographySavesLives {
	public partial class SubpageContent : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			Item i = Sitecore.Context.Item;
			if (i.Fields["Lead Content Image"] == null || !i.Fields["Lead Content Image"].HasValue)
				divContentImage.Visible = false;
			if (i.Fields["Page Description"] == null || !i.Fields["Page Description"].HasValue)
				divIntroText.Visible = false;
		}
	}
}