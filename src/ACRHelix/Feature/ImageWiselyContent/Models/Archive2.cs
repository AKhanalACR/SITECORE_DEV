using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.ImageWiselyContent.Models
{
  public class Archive2 : IArchive2
  {
    public ID Id { get; set; }

    public string Title { get; set; }

    public string SubTitle { get; set; }

    public IEnumerable<IArticlePage> ArticlePages { get; set; }
  }
}
