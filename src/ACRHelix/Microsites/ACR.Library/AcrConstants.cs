using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library
{
	public static class AcrConstants
	{
		public const string DevToolbarExpanded = "devtoolbarexpanded";

		/// <summary>
		/// SSOParams contains the string parameters use for the SSO implementation
		/// </summary>
		public static class SSOParams
		{
			public const string SSOCustomerTokenParam = "CT";
			public const string SSOVendorIdentifierParam = "vi";
			public const string SSOVendorTokenParam = "vt";
			public const string SSOLoggedIn = "ssologgedin";

			public const string SSOUsernameParam = "uname";
			public const string SSOPasswordParam = "password";

			public const string LoginRedirectUrlKey = "579d4714-bd40-4119-ac06-0f5d3547da61";
		}
		
		/// <summary>
		/// DateFormats contains common strings used in Date Formatting in DateTime.ToString()
		/// </summary>
		public static class DateFormats
		{
			public const string MonthDayYear = "MMMM d, yyyy";
			public const string MonthDay = "MMMM d";
			public const string DayYear = "d, yyyy";
			public const string MonthDayYearShortendSlashes = "M/d/yy";
		}
	}
}
