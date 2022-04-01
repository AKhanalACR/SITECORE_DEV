using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.RLI.Interfaces;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.RLI.Base
{
public partial class PageBaseItem : IMeta
{
	
    #region implementation of common IMeta
    public string MetaKeywords
    {
        get { return this.MetadataKeywords.Raw; }
    }
    public string MetaDate
    {
        get { return MetaUtils.GetDate(InnerItem);  }
    }

    public string MetaVerify
    {
        get { return null; }
    }

    public string MetaTitle
    {
        get { return this.Title.Raw; }
    }

    public string MetaDescription
    {
        get { return this.MetadataDescription.Raw; }
    }
    #endregion
}
}