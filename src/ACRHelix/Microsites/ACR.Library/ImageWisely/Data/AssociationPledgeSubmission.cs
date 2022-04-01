using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.ImageWisely.Data
{
	public partial class AssociationPledgeSubmission
	{
		private PledgeSubmissionsDataContext _dbPledges;

		public AssociationPledgeSubmission(Pledge pledge, string emailedTo)
		{
			if (pledge == null)
			{
				return;
			}

			new PledgeSubmission(pledge, emailedTo, null);
		}

		public AssociationPledgeSubmission(Pledge pledge, string emailedTo, string status)
		{
			if (pledge == null)
			{
				return;
			}

			Association = pledge.Institution;
			City = pledge.City;
			State = pledge.StateProvince;
			Country = pledge.Country;
			First_Name = pledge.FirstName;
			Last_Name = pledge.LastName;
			Title = pledge.Profession;
			Email = pledge.EmailAddress;
			DisplayOnHonorRoll = pledge.DisplayOnHonorRoll;

			SubmissionEmailedTo = pledge.EmailedTo;
			TimeSubmitted = DateTime.Now;
			Status = status;
		}

		public void InsertAssociationPledgeSubmission()
		{
			_dbPledges = new PledgeSubmissionsDataContext();
			// add the insert to the queue
			_dbPledges.AssociationPledgeSubmissions.InsertOnSubmit(this);
			_dbPledges.SubmitChanges();
			_dbPledges.Dispose();
		}

	}
}
