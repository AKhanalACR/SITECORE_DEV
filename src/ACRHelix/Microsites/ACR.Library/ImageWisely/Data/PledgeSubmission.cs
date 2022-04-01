using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.ImageWisely.Data
{
	public partial class PledgeSubmission
	{
	// get database connector
	private PledgeSubmissionsDataContext _dbPledges;

	public PledgeSubmission(Pledge pledge, string emailedTo)
		{
			if (pledge == null)
			{
				return;
			}

			new PledgeSubmission(pledge, emailedTo, null);
		}

		public PledgeSubmission(Pledge pledge, string emailedTo, string status)
		{
			if (pledge == null)
			{
				return;
			}

			First_Name = pledge.FirstName;
			Last_Name = pledge.LastName;
			Email = pledge.EmailAddress;
			Profession_Role = pledge.Profession;
			Primary_Institution = pledge.Institution;
			Country_of_Practice = pledge.Country;
			Primary_Practice_Type = pledge.PracticeType;
			How_Learned_About_Image_Wisely = pledge.HowLearned;
			Contact_With_Updates = pledge.ReceiveUpdates;
			Participate_in_Follow_Up_Survey = pledge.Participate;
			SubmissionEmailedTo = pledge.EmailedTo;
			TimeSubmitted = DateTime.Now;
			Status = status;
		}

		public void InsertImagingProfPledgeSubmission()
		{
			_dbPledges = new PledgeSubmissionsDataContext();
			// add the insert to the queue
			_dbPledges.PledgeSubmissions.InsertOnSubmit(this);
			_dbPledges.SubmitChanges();
			_dbPledges.Dispose();
		}
  }
}
