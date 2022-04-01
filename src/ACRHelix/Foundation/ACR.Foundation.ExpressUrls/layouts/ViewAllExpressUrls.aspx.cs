using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data;
using Sitecore.Data.Items;
using ACR.Foundation.ExpressUrls.Data;

namespace ACR.Foundation.ExpressUrls.layouts
{
    public partial class ViewAllExpressUrls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resultsLabel.Text = "";
            //List<UrlMap> goodUrls = new List<UrlMap>();
            List<ExpressUrl> expressUrls = new List<ExpressUrl>();
            //List<string> badItems = new List<string>();
            using (var expressUrlEntities = new ExpressUrlDatabase())
            {
                var urls = expressUrlEntities.UrlMaps.ToList();

                foreach (var u in urls)
                {
                   Item scitem = Database.GetDatabase("master").GetItem(u.destSitecoreId);
                    if (scitem != null)
                    {
                        //goodUrls.Add(u);
                        ExpressUrl url = new ExpressUrl()
                        {
                            ItemID = scitem.ID.ToString(),
                            ItemPath = scitem.Paths.Path,
                            Url = u.sourceUrl,
                            urlMapID = u.urlMapId
                        };
                        expressUrls.Add(url);                      
                    }
                    //else
                    //{
                    //    badItems.Add(u.destSitecoreId);
                    //}
                }
            }
            //resultsLabel.Text = string.Join(" - ", badItems);

            expressUrlsGV.DataSource = expressUrls;
            expressUrlsGV.DataBind();



        }
    }
}