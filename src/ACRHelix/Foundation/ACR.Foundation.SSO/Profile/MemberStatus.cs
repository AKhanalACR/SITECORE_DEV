using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.SSO.Profile
{
  public enum MemberStatus
  {
    NonMember,
    Active,
    Expired
  }

  public static class MemberStatusUtil
  {
    public static string ToSerializedString(this MemberStatus status)
    {
      switch (status)
      {
        case MemberStatus.NonMember:
          return "Non-Member";
        case MemberStatus.Active:
          return "Active";
        case MemberStatus.Expired:
          return "Expired";
        default:
          return string.Empty;
      }
    }

    public static MemberStatus GetMemberStatus(string status)
    {
      if (string.IsNullOrEmpty(status))
      {
        return MemberStatus.NonMember;
      }
      switch (status)
      {
        case "Non-Member":
          return MemberStatus.NonMember;
        case "Active":
          return MemberStatus.Active;
        case "Expired":
          return MemberStatus.Expired;
        default:
          return MemberStatus.NonMember;
      }
    }
  }
}