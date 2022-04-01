using ACRHelix.Feature.Identity.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public class ContactsFooter : IContactsFooter
    {
        public Guid Id { get; set; }
        [SitecoreField("Column 1")]
        public string Column1 { get; set; }
        [SitecoreField("Column 2")]
        public string Column2 { get; set; }
        [SitecoreField("Column 3")]
        public string Column3 { get; set; }
        [SitecoreField("Column 4")]
        public string Column4 { get; set; }
    }
}