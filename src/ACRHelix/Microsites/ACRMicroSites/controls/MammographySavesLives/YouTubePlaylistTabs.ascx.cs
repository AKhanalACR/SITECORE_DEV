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

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Sitecore.Express;


namespace ACR.controls.MammographySavesLives {
	public partial class YouTubePlaylistTabs : System.Web.UI.UserControl {
		protected IList<Video> AdsPlaylist {
			get {
				if (Cache["YouTube_AdsPlaylist"] == null) {
                    GetPlaylists().Wait();
				}
                return (IList<Video>)Cache["YouTube_AdsPlaylist"];
			}
			set {
				Cache.Insert("YouTube_AdsPlaylist", value, null, DateTime.Now.AddMinutes(YouTubeManager.CacheTimeoutMinutes), TimeSpan.Zero);
			}
		}

        protected IList<Video> StoriesPlaylist
        {
			get {
				if (Cache["YouTube_StoriesPlaylist"] == null) {
                    GetPlaylists().Wait();
				}
                return (IList<Video>)Cache["YouTube_StoriesPlaylist"];
			}
			set {
				Cache.Insert("YouTube_StoriesPlaylist", value, null, DateTime.Now.AddMinutes(YouTubeManager.CacheTimeoutMinutes), TimeSpan.Zero);
			}
		}

		protected void Page_Load(object sender, EventArgs e) {
            string playlist = Request["pl"] ?? "";
			string plItem = Request["item"] ?? "0";

			Video defaultAd = null;
			Video defaultStory = null;

			int playlistRetries = YouTubeManager.RequestRetries;
            try
            {
                GetPlaylists().Wait();
            }
            catch (AggregateException ex)
            {
                ErrorLabel.Visible = true;
                string errorText = ex.InnerExceptions.Aggregate("Could not retrieve YouTube information: ", (current, innerEx) => current + innerEx.Message);
                ErrorLabel.Text = errorText;
            }
            while (playlistRetries > 0)
            {
                try
                {
                    defaultAd = AdsPlaylist.First();
                    defaultStory = StoriesPlaylist.First();
                    break;
                }
                catch (Exception ex)
                {
                    playlistRetries--;
                    GetPlaylists().Wait();
                }
            }

            StoriesRepeater.DataSource = StoriesPlaylist ?? new List<Video>();
            StoriesRepeater.DataBind();

            AdsRepeater.DataSource = AdsPlaylist ?? new List<Video>();
            AdsRepeater.DataBind();

            try
            {
                int item = Int32.Parse(plItem);

                playlist = playlist.Trim();
                if (AdsPlaylist != null && ((playlist == "ads") && item < AdsPlaylist.Count))
                {
                    defaultAd = AdsPlaylist[item];
                    AdsVideo.AutoPlay = true;
                }
                else if (StoriesPlaylist != null && ((playlist == "stories") && item < StoriesPlaylist.Count))
                {
                    defaultStory = StoriesPlaylist[item];
                    StoriesVideo.AutoPlay = true;
                }
            }
            catch (AggregateException ex)
            {
                ErrorLabel.Visible = true;
                string errorText = ex.InnerExceptions.Aggregate("Could not retrieve YouTube information: ", (current, innerEx) => current + innerEx.Message);
                ErrorLabel.Text = errorText;
            }


            if (defaultAd == null || defaultStory == null)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = "Could not retrieve playlist data.";
            }
            else
            {
                AdsVideo.MainPlaylistVideo = true;
                AdsVideo.SetVideo(defaultAd);
                StoriesVideo.MainPlaylistVideo = true;
                StoriesVideo.SetVideo(defaultStory);

                ErrorLabel.Visible = false;
            }

            Control scripts = Page.ParseControl(@"
                <script type=""text/javascript"" src=""/js/MammographySavesLives/ui.core.js""></script>
                <script type=""text/javascript"" src=""/js/MammographySavesLives/ui.tabs.js""></script>
                <script type=""text/javascript"">
                    $(function() {
                        $('.video-player-tab-area').tabs({ fx: { opacity: 'toggle' } }).tabs('rotate', false);
                                    $( '.video-player-tab-area' ).bind( 'tabsshow', function(event, ui) {
                                            if(typeof(resetChannelAreaHeight)=='function')
                                                    resetChannelAreaHeight();
                                    });

                    });
                </script>
            ");
		    if (scripts != null) Page.FindControl("phInjectScripts").Controls.Add(scripts);
		}

        private async Task GetPlaylists()
        {
            var youtubeService = YouTubeManager.YouTubeService;

            double cacheTimeout = YouTubeManager.CacheTimeoutMinutes;
           
            string adsVideoListkey = "adsVideoList";
            string storiesVideolistKey = "storiesVideoList";
            object adsVideoList = Cache[adsVideoListkey];
            object storiesVideolist = Cache[storiesVideolistKey];

            if (adsVideoList == null || adsVideoList.GetType() != typeof(VideoListResponse))
            {
                int retries = YouTubeManager.RequestRetries;
                while (retries > 0)
                {
                    try
                    {
                        // Get the Ads playlist item from the API
                        var adsPlaylistRequest = youtubeService.PlaylistItems.List("snippet");
                        adsPlaylistRequest.PlaylistId = YouTubeManager.AdsPlaylistKey;
                        var adsPlaylistResponseItem = adsPlaylistRequest.Execute();
                        // Get the list of videos
                        adsVideoList = YouTubeManager.GetVideoListResponse(youtubeService, adsPlaylistResponseItem);
                        Cache.Insert(adsVideoListkey, adsVideoList, null, DateTime.Now.AddMinutes(cacheTimeout), TimeSpan.Zero);
                        break;
                    }
                    catch (Exception ex)
                    {
                        retries--;
                    }
                }
                if (adsVideoList == null)
                {
                    ErrorLabel.Visible = true;
                    ErrorLabel.Text = "Could not retrieve YouTube information.";
                    return;
                }
            }

            if (storiesVideolist == null || storiesVideolist.GetType() != typeof(VideoListResponse))
            {
                int retries = YouTubeManager.RequestRetries;
                while (retries > 0)
                {
                    try
                    {
                        // Get the stories playlist item from the API
                        var storiesPlaylistRequest = youtubeService.PlaylistItems.List("snippet");
                        storiesPlaylistRequest.PlaylistId = YouTubeManager.StoriesPlaylistKey;
                        var storiesPlaylistResponseItem = storiesPlaylistRequest.Execute();
                        // Get the list of videos
                        storiesVideolist = YouTubeManager.GetVideoListResponse(youtubeService, storiesPlaylistResponseItem);
                        Cache.Insert(storiesVideolistKey, storiesVideolist, null, DateTime.Now.AddMinutes(cacheTimeout), TimeSpan.Zero);
                        break;
                    }
                    catch (Exception ex)
                    {
                        retries--;
                    }
                }
                if (storiesVideolist == null)
                {
                    ErrorLabel.Visible = true;
                    ErrorLabel.Text = "Could not retrieve YouTube information.";
                    return;
                }
                
            }

            AdsPlaylist = ((VideoListResponse)adsVideoList).Items;
            StoriesPlaylist = ((VideoListResponse)storiesVideolist).Items;
        }

		protected string GetDateDifference(DateTime date) {
			int days = DateTime.Now.Subtract(date).Days;
			return days + " day" + (days != 1 ? "s" : "");
		}

	}
}