using System;
using System.Configuration;
using ACR.Library.Common.CustomItems.AcrCommon;

namespace ACR.layouts.Common
{
	public partial class ltRobotsTxt : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Sitecore.Context.Item.TemplateID.ToString() != RobotsTxtItem.TemplateId)
			{
				return;
			}

			RobotsTxtItem robots = Sitecore.Context.Item;
			Page.ContentType = "text/plain";

			litRobots.Text = "User-agent: *\r\nDisallow: /";

			if (ConfigurationManager.AppSettings["overrideDefaultRobotsTxt"] == "true")
			{
				litRobots.Text = robots.Robotstxt.Raw;
			}
		}
	}
}
