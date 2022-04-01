using ACRHelix.Feature.MyCtColonography.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MyCtColonography.Models
{
    public class MyCtColonography : IMyCtColonography
    {
        public Guid Id { get; }
        public string Title { get; }
    }
}