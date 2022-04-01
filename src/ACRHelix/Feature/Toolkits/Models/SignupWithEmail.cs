using ACRHelix.Feature.Toolkits.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ACRHelix.Feature.Toolkits.Models
{
    public class SignupWithEmail : ISignupWithEmail
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Teaser { get; set; }
        
    }
}