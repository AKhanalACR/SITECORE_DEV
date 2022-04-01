using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.RadPAC.ViewModels
{
    public class SignupViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Richtext { get; set; }
        public string ButtonText { get; set; }
    }
}