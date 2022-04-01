using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;

namespace ACR.layouts.ImageWisely
{
    public partial class sltContributors : System.Web.UI.UserControl
    {
        private StringBuilder _sbAlpha = new StringBuilder();
        private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private IEnumerable<ContributorItem> _allContributors;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Sitecore.Context.Item.TemplateID.ToString() != KeyContributorsItem.TemplateId)
                    return;

                KeyContributorsItem keyContributorsItem = Sitecore.Context.Item;
                //get all contributors
                _allContributors = keyContributorsItem.ContributorItems;

                //feed alphabet chars to repeater
                rptAlpha.DataSource = _alphabet.ToCharArray();
                rptAlpha.DataBind();

                //write alphabet nav
                ltlAlphaNav.Text = _sbAlpha.ToString();
            }

        }

        protected void rptAlpha_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var alpha = (char)e.Item.DataItem;
            
            IEnumerable<ContributorItem> contributors =
                _allContributors.Where(c => c.LastName.Raw != null && c.LastName.Raw[0] == alpha);

            if (contributors != null && contributors.Count() > 0)
            {
                var liAlphaBlock = (HtmlGenericControl) e.Item.FindControl("liAlphaBlock");
                var liAlphaBlockTop = (HtmlGenericControl)e.Item.FindControl("liAlphaBlockTop");
                var rptContributors = (Repeater)e.Item.FindControl("rptContributors");
                var ltlAlpha = (Literal)e.Item.FindControl("ltlAlpha");

                liAlphaBlock.Visible = true;
                liAlphaBlockTop.Visible = true;

                _sbAlpha.AppendFormat("<li><a href=\"#{0}\" title=\"{0}\" >{0}</a></li>", alpha.ToString());
                ltlAlpha.Text = String.Format("<a name=\"{0}\"></a>{0}", alpha.ToString());
                rptContributors.DataSource = contributors;
                rptContributors.DataBind();
            }
            else
            {
                _sbAlpha.AppendFormat("<li>{0}</li>", alpha.ToString());
            }
        }


        protected void rptContributors_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var contributor = (ContributorItem)e.Item.DataItem;

            var ltlContr = (Literal)e.Item.FindControl("ltlContr");
            ltlContr.Text = String.Format("{0} {1}, {2}, {3}", contributor.FirstName.Rendered, contributor.LastName.Rendered,
                                          contributor.Employer.Rendered, contributor.Location.Rendered);
        }
    }
}