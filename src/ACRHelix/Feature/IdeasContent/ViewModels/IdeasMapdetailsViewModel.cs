using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.ViewModels
{
    public class IdeasMapdetailsViewModel
    {
        public ID Id { get; set; }
        public string AddressPlaceholder { get; set; }
        public string NoResultsMessage { get; set; }
    }
}