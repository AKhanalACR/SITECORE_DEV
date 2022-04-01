using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.MyCtColonography.ViewModels
{
    public class MyCtColonographyViewModel
    {
        private IEnumerable<SelectListItem> _miles;
        public MyCtColonographyViewModel()
        {
            _miles = new List<SelectListItem>{
                new SelectListItem{ Value = "10", Text="10 miles" },
                new SelectListItem{ Value = "25", Text="25 miles"},
                new SelectListItem{ Value = "50", Text="50 miles", Selected = true },
                new SelectListItem{ Value = "100", Text="100 miles" },
                new SelectListItem{ Value = "200", Text="200 miles" },
                new SelectListItem{ Value = "500", Text="500 miles" }
            };
            
        }

        public string Address { get; set; }
        public string SelectedMile { get; set; }
        public IEnumerable<SelectListItem> Miles
        {
            get { return _miles; }
        }

    }
}