using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.Interfaces;

namespace ACR.Library.Radpac.Data
{
	public class Pledge : IPledge
	{
		public PledgeTypeItem PledgeType { get; set; }

		public string GroupName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Profession { get; set; }
		public string ProfessionalTitle{ get; set; }
		public string Institution { get; set; }
		public string City { get; set; }
		public string StateProvince { get; set; }
		public string Country { get; set; }
		public string PracticeType { get; set; }
		public string HowLearned { get; set; }
		public byte ReceiveUpdates { get; set; }
		public byte Participate { get; set; }
		public string EmailedTo { get; set; }
		public string Status { get; set; }

		public Pledge(PledgeTypeItem pledgeTypeItem)
		{
			PledgeType = pledgeTypeItem;
		}

		public bool CheckDuplicates(string emailAddr)
		{
			//check if duplicate pledge
			try
			{
				bool checkDupes = Convert.ToBoolean(ConfigurationManager.AppSettings["Radpac_CheckDuplicatePledges"]);
				if (checkDupes)
				{
					return DataHelper.IsDuplicateSubmission(emailAddr, PledgeType);
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string CheckOther(string ddVal, string textVal)
		{
			if (ddVal == "Other")
				return textVal;

			return ddVal;
		}
	}

	
}
