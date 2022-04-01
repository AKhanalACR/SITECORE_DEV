using ACRHelix.Feature.HTMLHead.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.HTMLHead.Services
{
    public interface IContentService
    {
        IHTMLHead GetHTMLHeadContent(string contentGuid);
    }
}