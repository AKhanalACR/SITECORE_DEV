using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.layouts.ACR.sublayouts.listing
{
    public partial class ModalityStepListing : System.Web.UI.UserControl
    {
        public static string ModalitySource { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            mainContent.FieldName = Types.Fields.MainContent;
            contentTitle.Field = Types.Fields.Headline;

            stillHaveQuestionsLink.Item = Sitecore.Context.Item;
            stillHaveQuestionsLink.Field = Types.Fields.ModalityQuestionLink;

            Item modalityListing = null;

            if (!string.IsNullOrEmpty(ModalitySource))
                modalityListing = Sitecore.Context.Database.GetItem(ModalitySource);
            else
            {
                Item current = Sitecore.Context.Item;
                modalityListing = current;
            }

            if (modalityListing != null)
                BindList(modalityListing.Axes.GetDescendants());

        }

        private void BindList(IEnumerable<Item> children)
        {
            var results = GetSubLists(children, Types.Templates.ModalityStep);
            BindRepeater(results, StepList);
            BindRepeater(results, StepNav);
        }

        private void BindRepeater(IEnumerable<Item> allowedItems, Repeater list)
        {
            StepList.Visible = allowedItems.Any();
            list.DataSource = allowedItems;
            list.DataBind();
        }

        private IEnumerable<Item> GetSubLists(IEnumerable<Item> children, string allowedTemplates)
        {
            var results = (from i in children
                           where (allowedTemplates.Contains(i.TemplateID.ToString()))
                           select i);

            return results;
        }

        protected void StepList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal currentNumber = (Literal)e.Item.FindControl("stepNumber");
            if (currentNumber != null)
            {
                int stepNumber = e.Item.ItemIndex + 1;
                currentNumber.Text = stepNumber > 9 ? "<u>" + stepNumber + "</u>" : "0<u>" + stepNumber + "</u>";
            }
            Item curItem = e.Item.DataItem as Item;
            Text txt = e.Item.FindControl("stepDetail") as Text;
            txt.Item = curItem;
        }

        protected void StepNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal currentNumber = (Literal)e.Item.FindControl("stepNumber");
            if (currentNumber != null)
            {
                int stepNumber = e.Item.ItemIndex + 1;
                currentNumber.Text = stepNumber > 9 ? "<u>" + stepNumber + "</u>" : "0<u>" + stepNumber + "</u>";
            }
        }
    }
}