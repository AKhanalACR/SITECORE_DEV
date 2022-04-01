using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Utils;

namespace ACR.controls.Common
{
    public partial class Pagination : System.Web.UI.UserControl
    {
        protected BasePagination _basePagination;
        protected readonly string _allQS = "showAll";
        protected string _url;
        protected int pageCount = 0;
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        public void SetData(int totalItemCount, int pageSize, int currentPageNumber, int windowSize, string url)
        {
            _url = url;
            _basePagination = new BasePagination(totalItemCount, pageSize, currentPageNumber, windowSize, false);

            List<PaginationNumber> paginationItems = _basePagination.GetPaginationItems();
            // if there is only 1 item, meaning just the first page listing, don't show it twice
            //  (It would look like "Page 1 1". Just "Page 1" will do)
            pageCount = paginationItems.Count;
            if (pageCount < 2)
            { paginationItems.Clear(); }

            rptPageLinks.Visible = true;

            rptPageLinks.DataSource = paginationItems;
            rptPageLinks.DataBind();

        }

        protected void rptPageLinks_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var paginationLink = (PaginationNumber)e.Item.DataItem;

            var lbPageLink = (LinkButton)e.Item.FindControl("lbPageLink");
            var ltlPipe = (Literal)e.Item.FindControl("ltlPipe");
            if (paginationLink.NotALink)
            {
                var ltlCurrentPage = (Literal)e.Item.FindControl("ltlCurrentPage");
                ltlCurrentPage.Text =  paginationLink.DisplayNumber;
                ltlCurrentPage.Visible = true;

                lbPageLink.Visible = false;
                if (e.Item.ItemIndex == pageCount - 1)
                    ltlPipe.Visible = false;
            }
            else
            {
                if (paginationLink.DisplayNumber == BasePagination.NextString ||
                    paginationLink.DisplayNumber == BasePagination.LastString ||
                    paginationLink.DisplayNumber == BasePagination.PreviousString ||
                    e.Item.ItemIndex == pageCount - 1)
                        ltlPipe.Visible = false;
               
                lbPageLink.Text = paginationLink.DisplayNumber;
                
            }
        }

        protected void lbPageLink_onClick(object sender, EventArgs e)
        {
            RenderURLAndRedirect(((LinkButton)sender).Text);
        }

        protected void RenderURLAndRedirect(string page)
        {
            var currentPageS = Request.QueryString[SearchPage.PageQS];
            int currentPage = currentPageS == null ? 1 : Int32.Parse(currentPageS);

            string url = HttpUtils.RemoveParameterFromUrl(Request, SearchPage.PageQS);

            if (page == BasePagination.NextString)
            {
                currentPage++;
                url = HttpUtils.RemoveParameterFromUrl(url, _allQS);
                url = HttpUtils.AddParameterToUrl(url, SearchPage.PageQS, currentPage.ToString());
            }
            else if (page == BasePagination.PreviousString)
            {
                currentPage--;
                url = HttpUtils.RemoveParameterFromUrl(url, _allQS);
                url = HttpUtils.AddParameterToUrl(url, SearchPage.PageQS, currentPage.ToString());
            }
            else if (page == _allQS)
            {
                url = HttpUtils.AddParameterToUrl(url, _allQS, "true");
            }
            else
            {
                currentPage = Int32.Parse(page);
                url = HttpUtils.RemoveParameterFromUrl(url, _allQS);
                url = HttpUtils.AddParameterToUrl(url, SearchPage.PageQS, currentPage.ToString());
            }

            Response.Redirect(url);
        }
    }
}