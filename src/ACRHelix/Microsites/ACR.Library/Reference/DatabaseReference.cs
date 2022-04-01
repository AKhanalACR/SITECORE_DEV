using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Diagnostics;

namespace ACR.Library.Reference
{
	public class DatabaseReference
	{
		private static Database _prod;
		public static Database Production
		{
			get 
			{ 
				if (_prod == null)
				{
					_prod = GetDatabase("production");
				}
				return _prod;
			}
		}

		private static Database _web;
		public static Database Preview
		{
			get
			{
				if (_web == null)
				{
					_web = GetDatabase("web");
				}
				return _web;
			}
		}

		private static Database _master;
		public static Database Master
		{
			get
			{
				if (_master == null)
				{
					_master = GetDatabase("master");
				}
				return _master;
			}
		}

		private static Database _importTarget;
		public static Database ImportTargetDatabase
		{
			get
			{
				if (_importTarget == null)
				{
					string importDbName = ConfigurationManager.AppSettings["Importer.TargetDatabase"];
					_importTarget = string.IsNullOrEmpty(importDbName) ? _master : GetDatabase(importDbName);
				}
				return _importTarget;
			}
		}

		public static Database Context
		{
			get
			{
				//If the context is core, we are in the content editor and should return the master db
				if (Sitecore.Context.Database == null || Sitecore.Context.Database.Name == "core")
				{
					return Master ?? Preview;
				}
				return Sitecore.Context.Database;
			}
		}

		private static Database GetDatabase(string name)
		{
			try
			{
				return Factory.GetDatabase(name);
			}
			catch (Exception ex)
			{
				Log.Debug("Could not fetch Database " + name, typeof(DatabaseReference));
				return null;
			}
		}
	}
}
