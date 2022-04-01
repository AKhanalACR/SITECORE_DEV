using ACRHelix.Feature.CareerCenter.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CareerCenter.Models
{
    public interface ICareerCenter : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }
    }
}