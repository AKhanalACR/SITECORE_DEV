using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Models.Chapters
{
  public class ChapterMember : IComparable<ChapterMember>  {
    public string MemberName { get; set; }
    public string Position { get; set; }

    public string LastName { get; set; }

    public int CompareTo(ChapterMember other)
    {
      Dictionary<string, int> levelsDict = new Dictionary<string, int>();

      //Level definitions for Chapter Members
      levelsDict.Add("President", 1);
      levelsDict.Add("President Elect", 2);
      levelsDict.Add("Vice President", 3);
      levelsDict.Add("First Vice President", 4);
      levelsDict.Add("Second Vice President", 5);
      levelsDict.Add("Treasurer", 6);
      levelsDict.Add("Secretary/Treasurer", 7);
      levelsDict.Add("Secretary", 8);
      levelsDict.Add("Immediate Past President", 9);
      levelsDict.Add("Fellowship Chair", 10);
      levelsDict.Add("Membership Chair", 11);
      levelsDict.Add("CEO", 12);
      levelsDict.Add("Executive Director", 13);
      levelsDict.Add("Executive Secretary", 14);
      levelsDict.Add("Staff", 15);

      //Level definitions for Committee Leaders
      levelsDict.Add("Chair", 1);
      levelsDict.Add("Co-Chair", 2);
      levelsDict.Add("Vice Chair", 3);
      //levelsDict.Add("Staff", 4);

      //If the position isn't found rank last
      int thisLevel = 14;
      if (levelsDict.ContainsKey(this.Position))
        thisLevel = levelsDict[this.Position];

      int otherLevel = 14;
      if (levelsDict.ContainsKey(other.Position))
        otherLevel = levelsDict[other.Position];

      //If rank is the same sort by name
      if (thisLevel != otherLevel)
      {
        return thisLevel - otherLevel;
      } else
      {
        return String.Compare(this.MemberName, other.MemberName);
      }
    }
  }
}