using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public class StateByState : IStateByState
    {
        public ID Id { get; set; }
        public string Title { get; set; }

        public string StateDdlLabel { get; set; }
        public bool ShowStateDdl { get; set; }

        public Link ParentPage { get; set; }
    }
}