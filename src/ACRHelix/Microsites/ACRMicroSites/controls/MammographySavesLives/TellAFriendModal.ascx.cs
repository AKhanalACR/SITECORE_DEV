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
using System.Net.Mail;
using Sitecore;
using Sitecore.Web;

namespace ACR.controls.MammographySavesLives {
	public partial class TellAFriendModal : System.Web.UI.UserControl {
		protected void Page_Load(object sender, EventArgs e) {
			string txtMessageAutoURL = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item);

			if (!txtMessage.Text.Contains(Sitecore.Web.WebUtil.CurrentPage.Request.Url.Host))
				txtMessage.Text += "\n\n" + txtMessageAutoURL;
		}

		protected void btnSend_Click(object sender, EventArgs e) {
			try {
				string body = txtMessage.Text;
				MailMessage message = new MailMessage(txtEmail.Text, txtFriend.Text, "Mammography Saves Lives", body);
				MainUtil.SendMail(message);
				Response.Redirect(Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Item));
			} catch (Exception ex) {
				//TODO: error message
				throw (ex);
			}
		}
	}
}