using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface IWelcomeHub : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        Image Image { get; set; }
        Link Link { get; set; }      
        string BgColor { get; set; }

        [SitecoreQuery(".//*[@@templateid='{26DFA1AE-7D76-48AE-B51B-A797CCBC68EB}']", IsRelative = true)]
        IEnumerable<IWelcomeHubItem> WelcomeHubItems { get; set; }
        
    }
}