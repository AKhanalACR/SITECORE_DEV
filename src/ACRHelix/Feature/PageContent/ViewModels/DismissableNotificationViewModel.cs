using ACRHelix.Feature.PageContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
    public class DismissibleNotificationViewModel
    {
        public ID Id { get; set; }
        public string NotificationText { get; set; }
    }
}