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
using ACR.Library;
using System.Collections.Generic;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;


namespace ACR.controls.MammographySavesLives {
	public partial class YouTubeVideo : System.Web.UI.UserControl {
		#region Configuration
		private string _normalPlayerUrl {
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeNormalPlayer"); }
		}

		private string _normalPlayerNoControlsUrl
		{
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeNormalPlayerNoControls"); }
		}

		private string _chromelessPlayerUrl {
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeChromelessPlayer"); }
		}
		#endregion

		#region User Control Parameters
		public string VideoID {
			get {
				return (string)ViewState["VideoID"];
			}
			set { ViewState["VideoID"] = value; }
		}

		public bool MainPlaylistVideo
		{
			get
			{
				if (ViewState["MainPlaylistVideo"] == null)
				{
					ViewState["MainPlaylistVideo"] = false;
				}
				return (bool)ViewState["MainPlaylistVideo"];
			}
			set { ViewState["MainPlaylistVideo"] = value; }
		}

		public string Width {
			get {
				if (ViewState["VideoWidth"] == null) {
					ViewState["VideoWidth"] = "100%";
				}
				return (string)ViewState["VideoWidth"];
			}
			set { ViewState["VideoWidth"] = value; }
		}

		public string Height {
			get {
				if (ViewState["VideoHeight"] == null) {
					ViewState["VideoHeight"] = "100%";
				}
				return (string)ViewState["VideoHeight"];
			}
			set { ViewState["VideoHeight"] = value; }
		}

		public bool AllowFullScreen {
			get {
				if (ViewState["AllowFullScreen"] == null) {
					ViewState["AllowFullScreen"] = true;
				}
				return (bool)ViewState["AllowFullScreen"];
			}
			set { ViewState["AllowFullScreen"] = value; }
		}

		public bool AllowScriptAccess {
			get {
				if (ViewState["AllowScriptAccess"] == null) {
					ViewState["AllowScriptAccess"] = true;
				}
				return (bool)ViewState["AllowScriptAccess"];
			}
			set { ViewState["AllowScriptAccess"] = value; }
		}

		public string CssClass {
			get {
				return (string)ViewState["CssClass"];
			}
			set { ViewState["CssClass"] = value; }
		}

		public string BackgroundColor {
			get {
				return (string)ViewState["BackgroundColor"];
			}
			set { ViewState["BackgroundColor"] = value; }
		}

		public bool Chromeless {
			get {
				if (ViewState["Chromeless"] == null) {
					ViewState["Chromeless"] = false;
				}
				return (bool)ViewState["Chromeless"];
			}
			set { ViewState["Chromeless"] = value; }
		}

		public bool NormalNoControls
		{
			get
			{
				if (ViewState["NormalNoControls"] == null)
				{
					ViewState["NormalNoControls"] = false;
				}
				return (bool)ViewState["NormalNoControls"];
			}
			set { ViewState["NormalNoControls"] = value; }
		}

		public bool ShowDescriptionBox {
			get {
				if (ViewState["ShowDescriptionBox"] == null) {
					ViewState["ShowDescriptionBox"] = true;
				}
				return (bool)ViewState["ShowDescriptionBox"];
			}
			set { ViewState["ShowDescriptionBox"] = value; }
		}
		public bool EnableJSAPI {
			get {
				if (ViewState["EnableJSAPI"] == null) {
					ViewState["EnableJSAPI"] = false;
				}
				return (bool)ViewState["EnableJSAPI"];
			}
			set { ViewState["EnableJSAPI"] = value; }
		}
		public bool AutoPlay {
			get {
				if (ViewState["AutoPlay"] == null) {
					ViewState["AutoPlay"] = false;
				}
				return (bool)ViewState["AutoPlay"];
			}
			set { ViewState["AutoPlay"] = value; }
		}
		#endregion

		#region Properties
		private string _playerContainerID = string.Empty;
		public string PlayerContainerID {
			get { return _playerContainerID; }
		}

		private string _playerID = string.Empty;
		public string PlayerID {
			get { return _playerID; }
		}
		#endregion

		protected void Page_Load(object sender, EventArgs e) {
			if (string.IsNullOrEmpty(VideoID))
			{
				ClearVideoScript();
			}
			else
			{
				if (!MainPlaylistVideo)
				{
					SetVideo(VideoID);
				}
			}

			DescriptionBoxPlaceHolder.Visible = ShowDescriptionBox;
		}

		public void SetVideo(String videoID) {
			double cacheTimeout = YouTubeManager.CacheTimeoutMinutes;
			string key = "Video" + videoID;
			object v = Cache[key];
            if (v == null || v.GetType() != typeof(Video))
            {
                int retries = YouTubeManager.RequestRetries;
                while (retries > 0)
                {
                    try
                    {
                        YouTubeService youtubeService = YouTubeManager.YouTubeService;
                        v = YouTubeManager.GetVideoListResponse(youtubeService, null, videoID).Items[0];
                        Cache.Insert(key, v, null, DateTime.Now.AddMinutes(cacheTimeout), TimeSpan.Zero);
                        break;
                    }
                    catch (Exception ex)
                    {
                        retries--;
                    }
                }

                if (v == null)
                {
                    ErrorLabel.Visible = true;
                    ErrorLabel.Text = "Could not retrieve video data.";
                    return;
                }
            }
			
			SetVideo((Video)v, videoID);
		}

		public void SetVideo(Video video)
		{
			SetVideo(video, string.Empty);
		}

		public void SetVideo(Video video, string videoId) {
			VideoID = videoId != string.Empty ? videoId : video.Id;

            TitleLiteral.Text = video.Snippet.Title;
			UserNameLiteral.Text = video.Snippet.ChannelTitle;
            PublishedLiteral.Text = Convert.ToDateTime(video.Snippet.PublishedAt).ToString(AcrConstants.DateFormats.MonthDayYear);
			ViewsLiteral.Text = video.Statistics.ViewCount.ToString();
			DescriptionLiteral.Text = video.Snippet.Description;

			RenderVideoScript();
		}

		protected void RenderVideoScript() {
			string id = Guid.NewGuid().ToString();

			_playerContainerID = "player-container_" + id;
			_playerID = "player_" + id;

			StringBuilder player = new StringBuilder();
      player.Append("<div class=\"cookieconsent-optout-marketing cookiebot-video\" style=\"display: none; \">Please <a href=\"javascript: Cookiebot.renew()\">accept marketing cookies</a> to to view this content.</div>");
			player.Append("<div class=\"player-container\" id=\"");
			player.Append(_playerContainerID);
			player.Append("\" v=\"");
			player.Append(VideoID);
			player.Append("\"></div>\n");

			if (string.IsNullOrEmpty(CssClass) == false) {
				player.Insert(0, "<div class=\"" + CssClass + "\">\n");
				player.Append("</div>");
			}

			VideoScriptLiteral.Text = player.ToString();
		}

		protected void ClearVideoScript() {
			VideoScriptLiteral.Text = string.Empty;
		}
	}
}