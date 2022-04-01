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
    public class StateContributions : IStateContributions
    {
        public ID Id { get; set; }

        public string Name { get; set; }

        public string MarchMadness { get; set; }

        public string ContributionAmount { get; set; }

        public string Rank { get; set; }

        public string FundraisingForTheMonth { get; set; }

        public string HardMoneyTotal { get; set; }

        public Link ParentPage { get; set; }

    }
}