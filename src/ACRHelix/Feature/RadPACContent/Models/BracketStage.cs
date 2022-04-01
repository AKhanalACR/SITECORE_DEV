using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.RadPACContent.Models
{    
    public class BracketStage : IBracketStage
    {
        public ID Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }        

    }
}