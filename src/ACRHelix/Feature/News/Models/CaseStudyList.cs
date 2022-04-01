using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System.Web.Mvc;

namespace ACRHelix.Feature.News.Models
{

[SitecoreType(TemplateId = "{46880993-BACD-4E65-BC7D-ADEAAD7025F0}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
public class CaseStudyList : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    public virtual IEnumerable<Guid> TagFilter { get; set; }
    public virtual MultiSelectList TagList { get; set; }
    [SitecoreQuery("../..//*[@@templateid='{2C398991-B270-4F71-BEF9-A68DCA7283EA}']", IsRelative = true)]
    public virtual IEnumerable<CaseStudy> CaseStudies { get; set; }

    [SitecoreField("Tiles Per Page")]
    public virtual int TilesPerPage { get; set; }

    //public int PageCount { get; set; }
    //public int PageNumber { get; set; }
    public List<List<CaseStudy>> CastStudyPages
    {      
    get
      {
        int PageSize = 6;
        if (TilesPerPage != 0) PageSize = TilesPerPage;

        if (Sitecore.Context.PageMode.IsExperienceEditor)
        {
          PageSize = CaseStudies.Count();
        }

        List<List<CaseStudy>> listofList = new List<List<CaseStudy>>();
        int added = 0;
        List<CaseStudy> allNews = CaseStudies.ToList();
        while (added < CaseStudies.Count())
        {
          List<CaseStudy> mlist = new List<CaseStudy>();
          mlist = allNews.Skip(added).Take(PageSize).ToList();
          listofList.Add(mlist);
          added += mlist.Count;
        }
        return listofList;
      }
    }
  }
}