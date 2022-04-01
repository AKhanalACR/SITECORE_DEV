using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces;

namespace ACR.Library.Common.CustomItems
{
    public partial class GenericItem : IPageItem
    {
        public string PageTitle
        {
            get { return string.Empty; }
        }

        public string NavTitle
        {
            get { return string.Empty; }
        }

        public string NavUrl
        {
            get { return string.Empty; }
        }

        public string NavTarget
        {
            get { return string.Empty; }
        }
    }
}
