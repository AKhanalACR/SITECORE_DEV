using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Lucene.Indices
{
	public class BaseIndexSortTypes 
	{
		public static string CreatedDate { get { return "__created"; } }

		public static string SearchDate { get { return "_searchdate"; } }
		public static string SearchTitle { get { return "_searchtitle"; } }
	}
}
