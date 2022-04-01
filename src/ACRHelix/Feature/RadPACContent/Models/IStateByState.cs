using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public interface IStateByState : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }

        [SitecoreField("StateDropdownListLabel")]
        string StateDdlLabel { get; set; }

        [SitecoreField("Show State Dropdown List")]
        bool ShowStateDdl { get; set; }

        Link ParentPage { get; set; }
        
    }
}