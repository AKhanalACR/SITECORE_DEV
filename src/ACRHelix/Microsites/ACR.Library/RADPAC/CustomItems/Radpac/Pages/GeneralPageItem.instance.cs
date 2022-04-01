using System;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
public partial class GeneralPageItem 
{
    public String AssociatedPdfUrl
    {
        get
        {
            if (this.PDFLink.Field.TargetItem != null && LinkUtils.IsPdfLink(this.PDFLink.Field))
                return this.PDFLink.Url;

            return String.Empty;
        }
    }
}
}