using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ideas.Website.Controllers
{
    public class SearchBoxController : Controller
    {
        //private static ID SearchSettingsID = new ID("{66AFED50-275A-438D-BC4B-BA3CFCB92E7A}");
       // private static ID MainSearchPageField = new ID("{D2B03473-126B-450B-BF14-010AC3299DFD}");

        public ViewResult IdeasSearchBox()
        {
            return View("IdeasSearchBox");
        }

    }
}
