using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.Interfaces;

namespace ACR.Library.ImageWisely.Data
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
		#region changes made by Navamani
		[Obsolete("deprecating on form, considered deprecation app-wide but concern over DB related regression halted work.", false)]
		public byte Level1 { get; set; }
		[Obsolete("deprecating on form, considered deprecation app-wide but concern over DB related regression halted work.", false)]
		public byte Level2 { get; set; }
		[Obsolete("deprecating on form, considered deprecation app-wide but concern over DB related regression halted work.", false)]
		public byte Level3 { get; set; }
		#endregion 
		public byte DisplayOnHonorRoll { get; set; }
		public string EmailedTo { get; set; }
		public string Status { get; set; }
		public DateTime TimeSubmitted { get; set; }

		public Pledge()
		{
		}

		public Pledge(PledgeTypeItem pledgeTypeItem)
		{
			PledgeType = pledgeTypeItem;
		}

		public bool CheckDuplicates(string emailAddr)
		{
			//check if duplicate pledge
			try
			{
				bool checkDupes = Convert.ToBoolean(ConfigurationManager.AppSettings["ImageWisely_CheckDuplicatePledges"]);
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
			{
				return textVal;
			}

			return ddVal;
		}
	}

	
}
