using ACRHelix.Feature.Identity.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ACRHelix.Feature.Identity.Models
{
    public interface IIdeasNewsContacts : ICMSEntity
    {
        Guid Id { get; }
        [SitecoreField("Contacts")]
        string Contacts { get; }

    }
}