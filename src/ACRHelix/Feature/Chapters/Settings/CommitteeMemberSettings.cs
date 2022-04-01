using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Chapters.Settings
{
  public static class CommitteeMemberSettings
  {
    private static List<KeyValuePair<string, int>> _leadershipPositions;
    public static List<KeyValuePair<string, int>> DisplayedLeadershipPositions
    {
      get
      {
        if (_leadershipPositions == null)
        {
          _leadershipPositions = new List<KeyValuePair<string, int>>();
          _leadershipPositions.Add(new KeyValuePair<string, int>("Chair", 1));
          _leadershipPositions.Add(new KeyValuePair<string, int>("Co-Chair", 2));
          _leadershipPositions.Add(new KeyValuePair<string, int>("Vice Chair", 3));
          _leadershipPositions.Add(new KeyValuePair<string, int>("Chief", 4));
          _leadershipPositions.Add(new KeyValuePair<string, int>("Staff", 5));          
        }
        return _leadershipPositions;
      }
    }
  }
}
