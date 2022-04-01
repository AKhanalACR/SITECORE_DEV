using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Folders;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;

namespace ACR.layouts.Radpac
{
    public partial class sltListMembers : System.Web.UI.UserControl
    {
        private IEnumerable<TaskForceMemberItem> _members;
        private IEnumerable<TaskForceFolderItem> _folders;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Sitecore.Context.Item.TemplateID.ToString() != TaskForcePageItem.TemplateId)
                    return;

                TaskForcePageItem taskForcePageItem = Sitecore.Context.Item;
                //get all folders
                _folders = taskForcePageItem.TaskForceFolders;

                rptHeadings.DataSource = _folders;
                rptHeadings.DataBind();
            }
        }

        protected void rptHeadings_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var folder = (TaskForceFolderItem)e.Item.DataItem;
            if (folder == null) return;

            IEnumerable<TaskForceMemberItem> members = folder.TaskForceMembers;

            if (members != null && members.Count() > 0)
            {
                var liMemberBlock = (HtmlGenericControl)e.Item.FindControl("liMemberBlock");
                var rptMembers = (Repeater)e.Item.FindControl("rptMembers");
                var ltlHeading = (Literal)e.Item.FindControl("ltlHeading");

                liMemberBlock.Visible = true;
                ltlHeading.Text = (String.IsNullOrEmpty(folder.FolderName.Raw) ? folder.Name : folder.FolderName.Rendered);
                rptMembers.DataSource = members;
                rptMembers.DataBind();
            }
        }

        protected void rptMembers_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var member = (TaskForceMemberItem)e.Item.DataItem;
            if (member == null) return;

            var ltlMember = (Literal)e.Item.FindControl("ltlMember");
            if (String.IsNullOrEmpty(member.Title.Text))
                ltlMember.Text = String.Format("{0} {1}", member.FirstName.Rendered, member.LastName.Rendered);
            else
                ltlMember.Text = String.Format("{0} {1}, {2}", member.FirstName.Rendered, member.LastName.Rendered, member.Title.Rendered);
        }
    }
}