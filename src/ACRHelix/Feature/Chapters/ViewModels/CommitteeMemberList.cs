using ACR.Foundation.Personify.Models.Committees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Chapters.ViewModels
{
  public class CommitteeMemberList
  {
    public Models.CommitteeMemberList CommitteeListContent {get;set;}
    public List<CommitteeMember> Leadership { get; set; }
    public List<CommitteeMember> Members { get; set; }
  }
}