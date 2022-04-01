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
using Google.Apis.Json;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json.Linq;

namespace ACR.controls.MammographySavesLives
{
	internal class YouTubeSavedDataStore : IDataStore
	{
		private Dictionary<string, TokenResponse> _store;

		public YouTubeSavedDataStore()
		{
			_store = new Dictionary<string, TokenResponse>();
		}

		public YouTubeSavedDataStore(string key, string refreshToken)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentNullException("key");
			}

			if (string.IsNullOrEmpty(refreshToken))
			{
				throw new ArgumentNullException("refreshToken");
			}

			_store = new Dictionary<string, TokenResponse>();

			// add new entry
			StoreAsync<TokenResponse>(key, new TokenResponse() { RefreshToken = refreshToken, TokenType = "Bearer" }).Wait();
		}

		/// <summary>
		/// Remove all items
		/// </summary>
		/// <returns></returns>
		public async Task ClearAsync()
		{
			await Task.Factory.StartNew(() =>
			{
				_store.Clear();
			});
		}

		/// <summary>
		/// Remove single entry
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <returns></returns>
		public async Task DeleteAsync<T>(string key)
		{
			await Task.Factory.StartNew(() =>
			{
				// check type
				AssertCorrectType<T>();

				if (_store.ContainsKey(key))
				{
					_store.Remove(key);
				}
			});
		}

		/// <summary>
		/// Obtain object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <returns></returns>
		public async Task<T> GetAsync<T>(string key)
		{
			// check type
			AssertCorrectType<T>();

			if (_store.ContainsKey(key))
			{
				return await Task.Factory.StartNew(() => { return (T)(object)_store[key]; });
			}

			// key not found
			return default(T);
		}

		/// <summary>
		/// Add/update value for key/value
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public Task StoreAsync<T>(string key, T value)
		{
			return Task.Factory.StartNew(() =>
			{
				if (_store.ContainsKey(key))
				{
					_store[key] = (TokenResponse)(object)value;
				}
				else
				{
					_store.Add(key, (TokenResponse)(object)value);
				}
			});
		}

		/// <summary>
		/// Validate we can store this type
		/// </summary>
		/// <typeparam name="T"></typeparam>
		private void AssertCorrectType<T>()
		{
			if (typeof(T) != typeof(TokenResponse))
			{
				throw new NotImplementedException(typeof(T).ToString());
			}
		}
	}
}