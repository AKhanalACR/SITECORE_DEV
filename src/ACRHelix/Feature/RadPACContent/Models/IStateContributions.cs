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
    public interface IStateContributions : ICMSEntity
    {
        ID Id { get; set; }

        string Name { get; set; }

        string MarchMadness { get; set; }

        string ContributionAmount { get; set; }

        string Rank { get; set; }

        string FundraisingForTheMonth { get; set; }

        string HardMoneyTotal { get; set; }

        Link ParentPage { get; set; }

    }
}