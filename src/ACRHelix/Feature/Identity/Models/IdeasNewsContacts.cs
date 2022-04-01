using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Identity.Models
{
    public class IdeasNewsContacts : IIdeasNewsContacts
    {
        public Guid Id { get; }
        public string Contacts { get; }
    }
}