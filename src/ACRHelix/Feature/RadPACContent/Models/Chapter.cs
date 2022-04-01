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
    public class Chapter : IChapter
    {
        public ID Id { get; set; }
        public string State { get; set; }
        public string Division { get; set; }
        public string Stage { get; set; } 
    }
}