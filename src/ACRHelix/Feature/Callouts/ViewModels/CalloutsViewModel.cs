using System;
using System.Collections.Generic;
using Sitecore.Data;

namespace ACRHelix.Feature.Callouts.ViewModels
{
    public class CalloutsViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public bool HasTitle => !String.IsNullOrEmpty(Title);
        public string Body { get; set; }
        public IEnumerable<CalloutsItemViewModel> CalloutItems { get; set; } = new List<CalloutsItemViewModel>();

    }
}