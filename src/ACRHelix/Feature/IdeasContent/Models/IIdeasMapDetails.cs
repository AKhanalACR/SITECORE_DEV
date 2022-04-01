using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.Models
{
    public interface IIdeasMapDetails : ICMSEntity
    {
        ID Id { get; set; }
        [SitecoreField("Address Placeholder")]
        string AddressPlaceholder { get; set; }
        [SitecoreField("No Results Message")]
        string NoResultsMessage { get; set; }
    }
}