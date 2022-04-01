using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using Google.Apis.YouTube.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3.Data;
using Sitecore.StringExtensions;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;

namespace ACR.controls.MammographySavesLives {
	public class YouTubeManager {
		private static string _ytAppName {
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeAppName"); }
		}
        
		private static Dictionary<string, DateTime> _videoDates = null;
		protected static Dictionary<string, DateTime> VideoDates {
			get {
				// Use a session instead of a static variable in the instance of HttpContext to avoid caching issues
				return (HttpContext.Current != null ? (Dictionary<string, DateTime>)HttpContext.Current.Session["YouTubeManager_VideoDates"] : _videoDates);
			}
			set {
				if (HttpContext.Current != null) {
					HttpContext.Current.Session["YouTubeManager_VideoDates"] = value;
				} else {
					_videoDates = value;
				}
			}
		}

		public static string RefreshToken
		{
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTube.RefreshToken"); }
		}

		public static string Username {
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeUsername"); }
		}

		public static string AdsPlaylistKey {
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeAdsPlaylist"); }
		}

		public static string StoriesPlaylistKey {
			get { return Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeStoriesPlaylist"); }
		}

		private static Nullable<double> _cacheTimeout = null;
		public static double CacheTimeoutMinutes {
			get {
				if (_cacheTimeout == null) {
					try {
						_cacheTimeout = double.Parse(Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeDataTimeoutMinutes"));
					} catch {
						_cacheTimeout = 20;
					}
				}
				return (double)_cacheTimeout;
			}
		}

		private static Nullable<int> _requestRetries = null;
		public static int RequestRetries {
			get {
				if (_requestRetries == null) {
					try {
						_requestRetries = int.Parse(Sitecore.Configuration.Settings.GetSetting("MSL.YouTubeDataRequestRetries"));
					} catch {
						_requestRetries = 10;
					}
				}
				return (int)_requestRetries;
			}
		}
        
	    private static YouTubeService _youtubeService = null;
	    public static YouTubeService YouTubeService
	    {
	        get
	        {
                //UserCredential credential;
                string jsonPath = HttpContext.Current.Server.MapPath("msl_client_secrets.json");
                string refreshToken = YouTubeManager.RefreshToken;

        TokenResponse token = new TokenResponse()
        {
          RefreshToken = refreshToken
        };

        var credential = new UserCredential(new GoogleAuthorizationCodeFlow(
          new GoogleAuthorizationCodeFlow.Initializer {

            ClientSecrets = new ClientSecrets()
            {
              ClientId = "246570425129-jfo4q7jb6lhe2mu5e5bphqt728tjnii1.apps.googleusercontent.com",
              ClientSecret = "5CC0HyvskjpkktcN_Ns-I10N"
          }
        }), "user", token);


      /*
                using (var stream = new FileStream(jsonPath, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                           GoogleClientSecrets.Load(stream).Secrets,
                        // This OAuth 2.0 access scope allows for read-only access to the authenticated 
                        // user's account, but not other types of account access.
                           new[] { YouTubeService.Scope.YoutubeReadonly },
                           "user",
                           CancellationToken.None,
                           new YouTubeSavedDataStore("user", refreshToken)
                    ).Result;
                }*/

                _youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _ytAppName
                });

                return _youtubeService;
	        }
	    }

	    public static VideoListResponse GetVideoListResponse(YouTubeService youtubeService, PlaylistItemListResponse playlistItem = null, string videoId = "")
	    {
            string videoIdList = GetVideoIdListFromPlaylist(playlistItem);
            var videoRequest = youtubeService.Videos.List("snippet");
	        if (videoId.Length == 0 && videoId.IsNullOrEmpty() && playlistItem != null)
	        {
                videoRequest.Id = videoIdList;
	        }
	        else
	        {
                videoRequest.Id = videoId;
	        }
            var videoResponse = videoRequest.Execute();
            // Get the statictics part of the videos
            var videoStatisticRequest = youtubeService.Videos.List("statistics");
            if (videoId.Length == 0 && videoId.IsNullOrEmpty() && playlistItem != null)
	        {
	            videoStatisticRequest.Id = videoIdList;
	        }
            else
            {
                videoStatisticRequest.Id = videoId;
            }
	        var videoStatisticResponse = videoStatisticRequest.Execute();
            // copy over statistics data to the main response
            for (var i = 0; i < videoResponse.Items.Count; i++)
            {
                videoResponse.Items[i].Statistics = videoStatisticResponse.Items[i].Statistics;
            }
            return videoResponse;
	    }

        public static string GetVideoIdListFromPlaylist(PlaylistItemListResponse playlistItemList)
        {
            string list = String.Empty;
            
            if (playlistItemList != null)
            {
                StringBuilder videoIdList = new StringBuilder();
                foreach (var item in playlistItemList.Items)
                {
                    if (videoIdList.Length > 0)
                    {
                        videoIdList.Append(",");
                    }
                   videoIdList.Append(item.Snippet.ResourceId.VideoId);
                }
                list = videoIdList.ToString();
            }
            return list;
        }
    }
}
