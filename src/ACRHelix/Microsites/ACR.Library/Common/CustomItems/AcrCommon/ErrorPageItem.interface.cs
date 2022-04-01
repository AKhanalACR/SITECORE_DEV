using System;
using ACR.Library.Common.Interfaces;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.Common.CustomItems.AcrCommon
{
public partial class ErrorPageItem : IMeta
{
	#region Implementation of IMeta

	public string MetaTitle
	{
		get { return PageSettings.PageTitle.Text; }
	}

	public string MetaDescription
	{
		get { return string.Empty; }
	}

	public string MetaKeywords
	{
		get { return string.Empty; }
	}

	public string MetaDate
	{
		get { return string.Empty; }
	}

	public string MetaVerify
	{
		get { return string.Empty; }
	}

	#endregion
}
}