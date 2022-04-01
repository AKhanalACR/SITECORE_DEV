using ACRHelix.Feature.ImageWiselyContent.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class IndivPledgeFormViewModel
    {
        private IndividualPledge _individualPledge;
        private bool _isEmailExist;
        public IndivPledgeFormViewModel()
        {
            _individualPledge = new IndividualPledge();
            isEmailExists = false;
        }
        public ID Id { get; set; }
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ButtonText { get; set; }

        public string PledgeType { get; set; }

        public string SendFormDataTo { get; set; }

        public string ConfirmationEmailFrom { get; set; }

        public string ConfirmationEmailSubject { get; set; }

        public string ConfirmationEmailBody { get; set; }

        public string ValidationErrorMessage { get; set; }

        public IndividualPledge IndividualPledge
        {
            get { return _individualPledge; }
            set { _individualPledge = value; }
        }

        public bool isEmailExists
        {
            get { return _isEmailExist; }
            set { _isEmailExist = value; }
        }

    }
}