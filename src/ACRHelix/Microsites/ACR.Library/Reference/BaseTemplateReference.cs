using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Cache;
using Sitecore.Data.Items;

namespace ACR.Library.Reference
{
	public class BaseTemplateReference
	{
		private const string _baseTemplateCacheKey = "{3430DA57-64F0-4327-9C63-741293D6E6D9}";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="templateId"></param>
		/// <returns>True if the item is of the current template type or has a base template of the current type</returns>
		public static bool IsValidTemplate(Item item, string templateId)
		{
			if (item == null)
				return false;
			//If the item is of the current template type of has a base template of the current type
			//return true.
			if (IsValidTemplate(item.Template, templateId))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="templateItem"></param>
		/// <param name="templateId"></param>
		/// <returns>True if the item is of the current template type or has a base template of the current type</returns>
		public static bool IsValidTemplate(TemplateItem templateItem, string templateId)
		{
			if (templateItem == null)
			{
				return false;
			}
			//If the item is of the current template type of has a base template of the current type
			//return true.
			if (templateItem.ID.ToString().Equals(templateId) || HasBaseTemplate(templateItem, templateId))
			{
				return true;
			}

			return false;
		}

		public static bool HasBaseTemplate(TemplateItem template, string baseTemplateId)
		{
			//The boolean cache entry should be related to the template and the base template only
			//So lets construct a cache key that incorporates the 2
			//Also include the database, so master/web checks aren't pulled from the same cache
			string databaseName = (template.Database != null) ? template.Database.Name : "unknown";
			string cacheKey = _baseTemplateCacheKey + ":" + databaseName + "/" + template.ID.ToString() + "->" + baseTemplateId;
			BaseTemplateResolver b = new BaseTemplateResolver(template, baseTemplateId);
			return (ACRCache.GetFromCache(cacheKey, b.hasBaseTemplate)).Value;
		}

		private static List<string> GetAllBaseTemplateIds(TemplateItem template)
		{
			List<string> templates = new List<string>();
			if (template.BaseTemplates.Count() > 0)
			{
				foreach (TemplateItem baseTemplate in template.BaseTemplates)
				{
					templates.Add(baseTemplate.ID.ToString());
				}
				foreach (TemplateItem baseTemplate in template.BaseTemplates)
				{
					templates.AddRange(GetAllBaseTemplateIds(baseTemplate));
				}
			}
			return templates;
		}

		private class BaseTemplateResolver
		{
			private TemplateItem template;
			private string baseTemplateId;

			public BaseTemplateResolver(TemplateItem template, string baseTemplateId)
			{
				this.template = template;
				this.baseTemplateId = baseTemplateId;
			}

			public BoolWrapper hasBaseTemplate()
			{
				if (template == null) return new BoolWrapper(false);
				return new BoolWrapper(GetAllBaseTemplateIds(template).Any(templateId => baseTemplateId == templateId));
			}
		}

		private class BoolWrapper
		{
			private bool value;

			public bool Value
			{
				get { return value; }
			}

			public BoolWrapper(bool value)
			{
				this.value = value;
			}
		}
	}
}
