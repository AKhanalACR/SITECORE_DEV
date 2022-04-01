using ACRHelix.Feature.MyCtColonography.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MyCtColonography.Models
{
    public interface IMyCtColonography : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
    }
}