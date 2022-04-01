using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.controls.RLI
{
    public class RLIWidgetControl : System.Web.UI.UserControl
    {
        #region Properties

        private Sublayout _sublayout;
        /// <summary>
        /// The current sublayout.
        /// </summary>
        private Sublayout Sublayout
        {
            get
            {
                //if sublayout is null, then try to set it.
                if (_sublayout == null)
                {
                    _sublayout = Parent as Sublayout;
                }

                //return our sublayout
                return _sublayout;
            }
        }

        private string _dataSource;
        /// <summary>
        /// The data source set on the current sublayout.
        /// </summary>
        protected string DataSource
        {
            get
            {
                //if our data source has not been set, then try to set it
                if (string.IsNullOrEmpty(_dataSource))
                {
                    //if we have a sublayout then pull the data source from there
                    if (Sublayout != null)
                    {
                        _dataSource = Sublayout.DataSource;
                    }
                }

                //make sure our data source is at least an empty string
                if (_dataSource == null)
                {
                    _dataSource = string.Empty;
                }

                //return our data source
                return _dataSource;
            }
        }

        private Item _widgetItem;
        /// <summary>
        /// The current widget item source from either the data source or context item.
        /// </summary>
        public Item WidgetItem
        {
            get
            {
                //if we didn't yet find our widget item then do so
                if (_widgetItem == null)
                {
                    //if we have a data source then get our item from that.
                    if (!string.IsNullOrEmpty(DataSource))
                    {
                        _widgetItem = Sitecore.Context.Database.GetItem(DataSource);
                    }

                    //if we still don't have an item then source from context item
                    if (_widgetItem == null)
                    {
                        _widgetItem = Sitecore.Context.Item;
                    }
                }

                //return our widget item
                return _widgetItem;
            }
        }


        #endregion

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            return;
        }
    }
}