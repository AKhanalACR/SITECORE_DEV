using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Items;
using Sitecore.Web;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.Controls.ACR.Base
{
	public class AcrWidgetControl : System.Web.UI.UserControl
	{
		private DateTime _startTime;

		protected override void OnInit(EventArgs e)
		{
			_startTime = DateTime.Now;
			base.OnInit(e);
		}

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			TimeSpan ts = DateTime.Now.Subtract(_startTime);
			//NewRelic.Api.Agent.NewRelic.RecordResponseTimeMetric("Custom/Sublayouts/" + this.AppRelativeVirtualPath, ts.Milliseconds);
		}

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
				if (_dataSource == null || _dataSource == string.Empty)
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

		/// <summary>
		/// Whether or not our widget has content.  This will default to true.
		/// Depending on this value the widget content or a placeholder will
		/// be rendered.
		/// </summary>
		public bool HasContent
		{
			get
			{
				//if our has content flag wasn't set then default to true.
				if (ViewState["HasContent"] == null)
				{
					ViewState["HasContent"] = true;
				}

				//return our value
				return (bool)ViewState["HasContent"];
			}
			set
			{
				//set our value
				ViewState["HasContent"] = value;
			}
		}

		/// <summary>
		/// The url for our placeholder image.  The placeholder image
		/// will only be displayed if our HasContent flag is false, this
		/// property has a value, and the page is in preview or page edit mode.
		/// </summary>
		public string PlaceholderImageUrl { get; set; }

		#endregion

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			//if we have content then call out base render method and return
			if (HasContent)
			{
				base.Render(writer);
				return;
			}

			//we don't have content so we should check if we can successfully display
			//a placeholder image.
			//if we aren't in any of the valid page modes, then just return.
			if (!Sitecore.Context.PageMode.IsPreview && !Sitecore.Context.PageMode.IsExperienceEditorEditing)
			{
				return;
			}

			//if we don't have a placeholder image then just return as there is nothing to render.
			if (string.IsNullOrEmpty(PlaceholderImageUrl))
			{
				return;
			}

			//create our section tag that will contain our placeholder image
			HtmlGenericControl section = new HtmlGenericControl("section");
      section.Attributes.Add("class", "widget clearfix placeholder");
			//section.AddCssClass("widget");
			//section.AddCssClass("clearfix");
			//section.AddCssClass("placeholder");

			//create our placeholder image and add it to our section tag
			HtmlImage image = new HtmlImage();
			image.Src = PlaceholderImageUrl;
			section.Controls.Add(image);

			//render our section tag
			section.RenderControl(writer);
		}
	}
}
