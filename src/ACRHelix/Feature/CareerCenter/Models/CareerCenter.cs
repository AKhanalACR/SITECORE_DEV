using ACRHelix.Feature.CareerCenter.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CareerCenter.Models
{
    public class CareerCenter : ICareerCenter
    {
        public Guid Id { get; }
        public string Title { get; }
    }
}