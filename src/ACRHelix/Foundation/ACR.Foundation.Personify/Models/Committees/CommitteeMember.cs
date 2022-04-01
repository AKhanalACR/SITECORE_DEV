using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Models.Committees
{
  public class CommitteeMember
  {
    public string Name { get; set; }

    public string SearchName { get; set; }

    public string Position { get; set; }

    public int Order { get; set; }

  }
}