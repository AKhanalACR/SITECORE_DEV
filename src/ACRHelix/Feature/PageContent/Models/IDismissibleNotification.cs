using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface IDismissibleNotification : ICMSEntity
    {
        ID Id { get; }
        string NotificationText { get; set; }
    }
}