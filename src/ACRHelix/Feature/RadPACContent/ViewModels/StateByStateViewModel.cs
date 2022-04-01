
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Web.Mvc;
using System.Collections.Generic;
using ACRHelix.Feature.RadPACContent.Services.Entities;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class StateByStateViewModel
    {       
        public ID Id { get; set; }
        public string Title { get; set; }

        public string StateDdlLabel { get; set; }
        public bool ShowStateDdl { get; set; }

        public string State { get; set; }

        public IEnumerable<SelectListItem> States
        {
            get { return EntityItems.States; }
        }

        public Link ParentPage { get; set; }
    }
}