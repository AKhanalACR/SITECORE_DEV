using System.Collections.Generic;
using Sitecore.Collections;
using Sitecore.Search;

namespace ACR.Lucene.Parameters
{
   public class FieldValueSearchParam : SearchParam
   {
      public FieldValueSearchParam()
      {
         Filters = new SafeDictionary<string>();
      }

      public QueryOccurance Occurance { get; set; }

			public DateRangeSearchParam DateRange { get; set; }
      public SafeDictionary<string> Filters { get; set; }
   }
}
