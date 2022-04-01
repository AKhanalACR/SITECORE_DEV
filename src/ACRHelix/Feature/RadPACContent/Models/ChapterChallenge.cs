using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public class ChapterChallenge : IChapterChallenge
    {
        public ID Id { get; set; }

        public IEnumerable<IChapter> Chapters { get; set; }
      
    }
}