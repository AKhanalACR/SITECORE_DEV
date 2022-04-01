using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.CustomItems.ACR.Interface.Wrappers
{
	public class AcrPersonnelWrapper : IAcrPersonnel
	{
		public string PersonnelName { get; set; }

		public string PersonnelImageUrl { get; set; }

		public List<IAcrPersonnelDetail> ShortPersonnelDetails { get; set; }

		public List<IAcrPersonnelDetail> PersonnelDetails { get; set; }

		public string PersonnelBiography { get; set; }

		public string PersonnelUrl { get; set; }
	}
}
