using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public class LinkSectionItem : ILinkSectionItem
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public override bool Equals(object other) //note parameter is of type object
        {
            LinkSectionItem t = other as LinkSectionItem;
            return (t != null) ? Id.Equals(t.Id) : false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}