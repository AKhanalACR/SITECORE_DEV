using System;
using System.Text;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.MediaCenter
{
	public partial class SpokespersonItem
	{
		/// <summary>
		/// The full name of our spokesperson.  This includes their name and credentials.
		/// </summary>
		public string FullName
		{
			get
			{
				//if we dont have a name then just return empty string
				if (Name == null)
				{
					return string.Empty;
				}

				//initialize our full name with the users name
				StringBuilder fullName = new StringBuilder(Name.Text);

				//if we have credentials then add them
				if (Credentials != null && !string.IsNullOrEmpty(Credentials.Text))
				{
					fullName.Append(", " + Credentials.Text);
				}

				//return our full name
				return fullName.ToString();
			}
		}
	}
}