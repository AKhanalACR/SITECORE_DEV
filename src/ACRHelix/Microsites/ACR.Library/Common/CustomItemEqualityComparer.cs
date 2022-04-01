using System.Collections.Generic;
using Sitecore.Data.Items;

namespace ACR.Library.Common
{
	public class CustomItemEqualityComparer<T> : IEqualityComparer<T> where T:CustomItemBase
	{
		#region Implementation of IEqualityComparer<T>

		public bool Equals(T x, T y)
		{
			return x.ID == y.ID;
		}

		public int GetHashCode(T obj)
		{
			return obj.ID.GetHashCode();
		}

		#endregion
	}
}
