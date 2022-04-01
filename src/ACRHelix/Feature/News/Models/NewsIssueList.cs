using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.News.Models
{
  [SitecoreType(TemplateId = "{D148B274-415C-4208-B3F2-13148697612D}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class NewsIssueList : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField(FieldName = "Datasource", FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.DropTree)]
    public virtual string Datasource { get; set; }

    public virtual string Title { get; set; }

    [SitecoreField(FieldName = "Display Count")]
    public virtual int IssuesPerPage { get; set; }
  }
}