using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Chapters.Settings
{
  public class ChapterCategorySettings
  {
    public static string[] OfficerPositions = new string[] 
    {
        "President",
        "President Elect",
        "Vice President",
        "First Vice President",
        "Second Vice President",
        "Treasurer",
        "Secretary/Treasurer",
        "Secretary",
        "Immediate Past President",
        "Fellowship Chair",
        "Membership Chair",
        "CEO",
        "Executive Director",
        "Executive Secretary",
        "Staff"
    };

    public static string[] Councilors = new string[]
    {
      "Councilor 1st Term",
      "Councilor 2nd Term"
    };

    public static string[] AlternateCouncilors = new string[]{
      "Alternate Councilor",
      "Young Physician Alternate Councilor"
    };

    public static string[] CommiteeLeaders = new string[]
    {
      "Chair",
      "Co-Chair",
      "Vice Chair",
      "Staff"
    };
  }
}