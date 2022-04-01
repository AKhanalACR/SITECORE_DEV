using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using ACR.Foundation.ExpressUrls.Data;

namespace ACR.Foundation.ExpressUrls
{
    [Serializable]
    public class ViewExpressURLCodeBeside : DialogForm
    {
        protected Toolbutton DeleteButton;
        protected Listview ExpressUrlList;

        [HandleMessage("velir:addexpressurl")]
        protected void AddRemoveExpressUrls(Message message)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters["sitecoreId"] = this.ExpressUrlList.SelectedItems[0].ServerProperties["sitecoreId"].ToString();
            Context.ClientPage.Start(this, "ShowAddExpressUrl", parameters);
        }

        protected void DeleteConfirm(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {
                if (args.Result.ToLower().Equals("yes"))
                {
                    foreach (ListviewItem item in this.ExpressUrlList.SelectedItems)
                    {
                        /*
                        using (UrlMappingDataContext context = new UrlMappingDataContext())
                        {
                            context.DeleteExpressUrl((int)item.ServerProperties["urlMapId"]);
                        }*/
                        using (var db = new ExpressUrlDatabase())
                        {
                            int id = (int)item.ServerProperties["urlMapId"];
                            var sel = db.UrlMaps.FirstOrDefault(x => x.urlMapId == id);
                            db.UrlMaps.Remove(sel);
                            db.SaveChanges();
                        }
                    }
                    this.ReloadList();
                }
            }
            else
            {
                SheerResponse.Confirm("Are you sure you want to delete the selected Express Url?");
                args.WaitForPostBack();
            }
        }

        [HandleMessage("velir:deleteExpressUrl")]
        protected void DeleteExpressUrl(Message message)
        {
            Context.ClientPage.Start(this, "DeleteConfirm");
        }

        [HandleMessage("velir:enableDeleteButton")]
        protected void EnableDeleteButton(Message message)
        {
            if (!this.DeleteButton.Visible)
            {
                this.DeleteButton.Visible = true;
            }
        }

        protected void FillList(List<UrlMap> urls)
        {
            if (urls != null)
            {
                foreach (UrlMap map in urls)
                {
                  if (map.destSitecoreId != null)
                  {
                    Item item = Database.GetDatabase("master").GetItem(map.destSitecoreId);
                    //Item item = SitecoreItemFinder.GetItem(Factory.GetDatabase("master"), map.destSitecoreId);  
                    if (item != null)
                    {
                      ListviewItem control = new ListviewItem();
                      Context.ClientPage.AddControl(this.ExpressUrlList, control);
                      control.ID = Control.GetUniqueID("I");
                      control.Icon = item.Appearance.Icon;
                      control.Header = item.Paths.Path;
                      control.ServerProperties["urlMapId"] = map.urlMapId;
                      control.ServerProperties["sitecoreId"] = map.destSitecoreId;
                      control.ColumnValues["expressUrl"] = map.sourceUrl;
                    }
                  }
                }
            }
        }

        private void LoadAllUrls()
        {
            List<UrlMap> list = null;
            using (var db = new ExpressUrlDatabase())
            {
               list = db.UrlMaps.ToList();           
            }
            FillList(list);
        }

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);
            if (!Context.ClientPage.IsEvent)
            {
                this.LoadAllUrls();
            }
        }

        private void ReloadList()
        {
            this.ExpressUrlList.Controls.Clear();
            this.LoadAllUrls();
            SheerResponse.SetOuterHtml("ExpressUrlList", this.ExpressUrlList);
        }

        protected void RemoveFromList(ListviewItem item)
        {
            this.ExpressUrlList.Controls.Remove(item);
        }

        protected void ShowAddExpressUrl(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
            {
                this.ReloadList();
            }
            else
            {
                string uri = Sitecore.UIUtil.GetUri("control:xmlExpressUrlApp");
                if (!string.IsNullOrEmpty(args.Parameters["sitecoreId"]))
                {
                    uri = uri + "&id=" + args.Parameters["sitecoreId"];
                }
                SheerResponse.ShowModalDialog(uri, true);
                args.WaitForPostBack();
            }
        }
    }
}