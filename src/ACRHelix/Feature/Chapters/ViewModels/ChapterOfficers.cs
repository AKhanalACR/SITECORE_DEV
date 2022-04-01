using ACR.Foundation.Personify.Models.Chapters;
using ACRHelix.Foundation.Model;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Chapters.ViewModels
{
  public class ChapterOfficers
  {
    public List<ChapterMember> Officers { get; set; } = new List<ChapterMember>();

    public List<ChapterMember> Coucilors { get; set; } = new List<ChapterMember>();

    public List<ChapterMember> AlternateCouncilors { get; set; } = new List<ChapterMember>();
  }
}