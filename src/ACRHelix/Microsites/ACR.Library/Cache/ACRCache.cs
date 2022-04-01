using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace ACR.Library.Cache
{
	public class ACRCache
	{
		private static readonly Object lockObject;
		private static readonly IList<ACRCacheDependancy> dependancies;

		private static System.Web.Caching.Cache Cache
		{
			get
			{
				if(HttpContext.Current == null)
				{
					return null;
				}
				return HttpContext.Current.Cache;
			}
		}

		static ACRCache()
		{
			lockObject = new object();
			dependancies = new List<ACRCacheDependancy>();
		}

		public void EmptyCacheHandler(object sender, EventArgs args)
		{
			EmptyCache();
		}

		public static void EmptyCache()
		{
			lock (lockObject)
			{
				while (dependancies.Count > 0)
				{
					dependancies[0].DependancyChanged();
				}
			}
		}

		private static void AddToCache(Object obj, String key, DateTime expiration)
		{
			ACRCacheDependancy dependancy = new ACRCacheDependancy();
			if (Cache == null)
			{
				return;
			}
			Cache.Add(key, obj, dependancy, expiration, System.Web.Caching.Cache.NoSlidingExpiration,
												CacheItemPriority.Normal, null);
		}

		public delegate T CacheCallBack<T>();

		/// <summary>
		/// Retrieves the desired object from the cache. If the object is null, executes the callback
		/// method to set it up and store it in the cache.
		/// </summary>
		/// <typeparam name="T">A reference type</typeparam>
		/// <param name="key">The cache key, must be unique for each object</param>
		/// <param name="callback">A callback method to retrieve the object if it is not in cache.</param>
		/// <returns></returns>
		public static T GetFromCache<T>(string key, CacheCallBack<T> callback) where T : class
		{
			return GetFromCache<T>(key, TimeSpan.Zero, callback);
		}

		/// <summary>
		/// Retrieves the desired object from the cache. If the object is null, executes the callback
		/// method to set it up and store it in the cache.
		/// </summary>
		/// <typeparam name="T">A reference type</typeparam>
		/// <param name="key">The cache key, must be unique for each object</param>
		/// <param name="absoluteExpiration">A TimeSpan after which the item will expire from the cache.</param>
		/// <param name="callback">A callback method to retrieve the object if it is not in cache.</param>
		/// <returns></returns>
		public static T GetFromCache<T>(string key, TimeSpan absoluteExpiration, CacheCallBack<T> callback) where T : class
		{
			if (Cache != null)
			{
				Object cacheObject = Cache[key];
				if (cacheObject != null)
				{
					return (T)cacheObject;
				}
			}

			lock (lockObject)
			{
				if (Cache != null && Cache[key] != null)
				{
					return (T)Cache[key];
				}

				T newObj = callback();
				if (newObj != null && Cache != null)
				{
					AddToCache(newObj, key, absoluteExpiration != TimeSpan.Zero
																	? DateTime.Now.Add(absoluteExpiration)
																	: System.Web.Caching.Cache.NoAbsoluteExpiration);
				}
				return newObj;
			}
		}

		/// <summary>
		/// Retrieves the desired object from the cache. If the object is null, executes the callback
		/// method to set it up and store it in the cache.
		/// </summary>
		/// <typeparam name="T">A reference type</typeparam>
		/// <param name="key">The cache key, must be unique for each object</param>
		/// <param name="absoluteExpiration">The DateTime at which the item will expire from the cache.</param>
		/// <param name="callback">A callback method to retrieve the object if it is not in cache.</param>
		/// <returns></returns>
		public static T GetFromCache<T>(string key, DateTime absoluteExpiration, CacheCallBack<T> callback) where T : class
		{
			if (Cache != null)
			{
				Object cacheObject = Cache[key];
				if (cacheObject != null)
				{
					return (T)cacheObject;
				}
			}

			lock (lockObject)
			{
				if (Cache != null && Cache[key] != null)
				{
					return (T)Cache[key];
				}

				T newObj = callback();
				if (newObj != null && Cache != null)
				{
					AddToCache(newObj, key,  absoluteExpiration);
				}
				return newObj;
			}
		}

		internal class ACRCacheDependancy : CacheDependency
		{
			public ACRCacheDependancy()
			{
				// Subscribe to the dependancy list
				dependancies.Add(this);
				FinishInit();
			}

			public void DependancyChanged()
			{
				NotifyDependencyChanged(this, EventArgs.Empty);
			}

			protected override void DependencyDispose()
			{
				dependancies.Remove(this);
			}
		}
	}
}
