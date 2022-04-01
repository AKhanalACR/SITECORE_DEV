using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using CustomItemGenerator.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace ACR.Library.CustomSitecore.CustomFields
{
	public partial class CustomNameValueListField : BaseCustomField<CustomCustomField>
	{
		public CustomNameValueListField(Item item, Field field)
			: base(item, field)
		{
		}

		private NameValueCollection _collection;

		public NameValueCollection NameValueList
		{
			get
			{
				if (_collection == null)
				{
					if (item.Fields[field.InnerField.Name] == null || !item.Fields[field.InnerField.Name].HasValue) return new NameValueCollection();

					string nvc = item.Fields[field.InnerField.Name].Value;
					_collection = HttpUtility.ParseQueryString(nvc);
				}

				return _collection;
			}
		}
	}
}
