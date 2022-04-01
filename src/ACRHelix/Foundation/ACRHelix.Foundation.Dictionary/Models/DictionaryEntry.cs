using ACRHelix.Foundation.Dictionary.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.Dictionary.Models
{
    public class DictionaryEntry : IDictionaryEntry
    {
        public Guid Id { get; set; }
        public string Phrase { get; set; }
    }
}