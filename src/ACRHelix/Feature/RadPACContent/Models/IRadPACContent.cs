using ACRHelix.Feature.RadPACContent.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public interface IRadPACContent : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
    }
}