using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Radpac.CustomItems.Radpac.Components;

namespace ACR.Library.Radpac.Interfaces
{
	public interface IPledge
	{
		PledgeTypeItem PledgeType { get; set; }
		string GroupName {get; set;}
		string FirstName {get; set;} 
		string LastName {get; set;}
		string EmailAddress {get; set;}
		string Profession {get; set;}
		string ProfessionalTitle { get; set; }
		string Institution {get; set;}
		string City { get; set; }
		string StateProvince { get; set; }
		string Country {get; set;}
		string PracticeType {get; set;}
		string HowLearned {get; set;}
		byte ReceiveUpdates {get; set;}
		byte Participate {get; set;} 
		string EmailedTo {get; set;}
		string Status { get; set; }
	}
}
