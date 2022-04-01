
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Web.Mvc;
using System.Collections.Generic;
using ACRHelix.Feature.RadPACContent.Services.Entities;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class StateContributionsViewModel
    {
        public ID Id { get; set; }

        public string MarchMadness { get; set; }

        public string ContributionAmount { get; set; }

        public string Rank { get; set; }

        public string FundraisingForTheMonth { get; set; }

        public string HardMoneyTotal { get; set; }

        public string State { get; set; }

        public Link ParentPage { get; set; }

        public string Ranked { get; set; }

        public string TheMonthsAmount { get; set; }

        public string MoneyTotal { get; set; }

        public IEnumerable<SelectListItem> States
        {
            get { return EntityItems.States; }
        }
    }
}