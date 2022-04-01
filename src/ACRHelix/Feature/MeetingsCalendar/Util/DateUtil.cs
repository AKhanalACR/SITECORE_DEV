using ACR.Foundation.Personify.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ACRHelix.Feature.MeetingsCalendar.Util
{
  public static class DateUtil
  {
    public static string GetFormattedDate(ProductStubItem product)
    {
      return DisplayMeetingDateRange(product.MeetingStartDate, product.MeetingEndDate);
    }

    public static string DisplayMeetingDateRange(DateTime startDate, DateTime endDate)
    {
      StringBuilder sb = new StringBuilder();
      if (startDate.Year == endDate.Year)
      {
        sb.Append(startDate.ToString("MMMM d - "));
      }
      else
      {
        sb.Append(startDate.ToString("MMMM d, yyyy - "));
      }

      if (startDate.Month == endDate.Month)
      {
        sb.Append(endDate.ToString("d, yyyy"));
      }
      else
      {
        sb.Append(endDate.ToString("MMMM d, yyyy"));
      }
      return sb.ToString();
    }
  }
}