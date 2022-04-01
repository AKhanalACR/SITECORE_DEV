using ACRHelix.Feature.Ideas.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Ideas.Models
{
    public interface IIdeas : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
    }
}