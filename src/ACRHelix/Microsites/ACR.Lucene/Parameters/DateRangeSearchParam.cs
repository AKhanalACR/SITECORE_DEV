using System;
using System.Collections.Generic;
using Sitecore.Search;

namespace ACR.Lucene.Parameters
{
   public class DateRangeSearchParam : SearchParam
   {
      public class DateRangeField
      {
         protected DateTime startDate;
         protected DateTime endDate;

         public DateRangeField() { }

         public DateRangeField(string fieldName, DateTime startDate, DateTime endDate)
         {
            FieldName = fieldName.ToLowerInvariant();
            StartDate = startDate;
            EndDate = endDate;
         }

         #region Properties

         public bool InclusiveStart { get; set; }

         public bool InclusiveEnd { get; set; }

         public string FieldName { get; set; }

         public DateTime StartDate
         {
            get { return startDate; }
            set
            {
               startDate =  value;
            }
         }

         public DateTime EndDate
         {
            get { return endDate; }
            set
            {
               endDate = value;
            }
         }

         #endregion Properties
      }

      public List<DateRangeField> Ranges { get; set; }

      public QueryOccurance Occurance { get; set; }
   }
}
