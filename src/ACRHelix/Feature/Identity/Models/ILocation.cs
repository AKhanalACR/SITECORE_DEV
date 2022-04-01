using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public interface ILocation : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
        [SitecoreField("Address 1")]
        string Address1 { get; }
        string City { get; }
        string State { get; }
        string Zip { get; }
        string Phone { get; }
    }
}