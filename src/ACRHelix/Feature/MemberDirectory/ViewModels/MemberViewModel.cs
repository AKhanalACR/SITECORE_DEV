using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.MemberDirectory.Models;
using ACR.Foundation.Personify.Models.Members;
using System.Text;

namespace ACRHelix.Feature.MemberDirectory.ViewModels
{
    public class MemberViewModel
    {
      public Member Member { get; set; }

    public string BuildDetail()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("<h2>Member Contact Information</h2>");
      //ghsu 20130606
      //sb.AppendFormat("<h3>{0}</h3>", row["sort_name"]);
      sb.AppendFormat("<h3>{0}</h3>", Member.LabelName);

      //unfortunately, we have variable row data returned, 
      //so we have to check that each column exists before accessing the value.
      if (!string.IsNullOrWhiteSpace(Member.Attn))
      {
        sb.AppendFormat("<p><strong>Attention:</strong> {0}</p>", Member.Attn);
      }
      sb.Append("<p><strong>Address:</strong> " + "<br/>");
      if (!string.IsNullOrWhiteSpace(Member.Address1))
        sb.Append(Member.Address1 + "<br/>");
      if (!string.IsNullOrWhiteSpace(Member.Address2))
        sb.Append(Member.Address2 + "<br/>");
      if (!string.IsNullOrWhiteSpace(Member.CityStreetZip))
        sb.Append(Member.CityStreetZip + "<br/>");
      if (!string.IsNullOrWhiteSpace(Member.Country))
        sb.Append(Member.Country);
      sb.Append("<p>");

      if (!string.IsNullOrWhiteSpace(Member.BusinessPhone))
        sb.AppendFormat("<p><strong>Business Phone:</strong> {0}</p>", Member.BusinessPhone);

      if (!string.IsNullOrWhiteSpace(Member.BusinessFax))
        sb.AppendFormat("<p><strong>Business Fax:</strong> {0}</p>", Member.BusinessFax);

      if (!string.IsNullOrWhiteSpace(Member.Email))
        sb.AppendFormat("<p><strong>Email:</strong> {0}</p>", Member.Email);

      if (Member.MemberSince.HasValue)
      {
          sb.AppendFormat("<p><strong>ACR Member Since:</strong> {0}</p>", Member.MemberSince.Value.ToString("MMMM dd, yyyy"));     
      }
      return sb.ToString();
    }
    }
}