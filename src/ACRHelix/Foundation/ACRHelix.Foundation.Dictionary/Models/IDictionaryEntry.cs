using ACRHelix.Foundation.Dictionary.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.Dictionary.Models
{
    public interface IDictionaryEntry : ICMSEntity
    {
        Guid Id { get; }
        string Phrase { get; }
    }
}