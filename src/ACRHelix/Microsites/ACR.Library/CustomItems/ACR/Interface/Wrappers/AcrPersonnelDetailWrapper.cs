using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.CustomItems.ACR.Interface.Wrappers
{
	public class AcrPersonnelDetailWrapper : IAcrPersonnelDetail
	{
		public AcrPersonnelDetailType PersonnelDetailType { get; set; }

		public string PersonnelDetailText { get; set; }

		public string PersonnelDetailUrl { get; set; }
	}
}
