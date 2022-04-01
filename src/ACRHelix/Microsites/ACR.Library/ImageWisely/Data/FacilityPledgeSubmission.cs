using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.ImageWisely.Data
{
	public partial class FacilityPledgeSubmission
	{
		// get database connector
	private PledgeSubmissionsDataContext _dbPledges;

	public FacilityPledgeSubmission(Pledge pledge, string emailedTo)
		{
			if (pledge == null)
				return;

			new PledgeSubmission(pledge, emailedTo, null);
		}

		public FacilityPledgeSubmission(Pledge pledge, string emailedTo, string status)
		{
			if (pledge == null)
				return;

			Facility = pledge.Institution;
			City = pledge.City;
			State = pledge.StateProvince;
			Country = pledge.Country;
			First_Name = pledge.FirstName;
			Last_Name = pledge.LastName;
			Title = pledge.Profession;
			Email = pledge.EmailAddress;
			DisplayOnHonorRoll = pledge.DisplayOnHonorRoll;
			#region changes made by Navamani
			Level1 = pledge.Level1;
			Level2 = pledge.Level2;
			Level3 = pledge.Level3;
			#endregion
			SubmissionEmailedTo = pledge.EmailedTo;
			TimeSubmitted = DateTime.Now;
			Status = status;
		}

		public void InsertFacilityPledgeSubmission()
		{
			_dbPledges = new PledgeSubmissionsDataContext();
			// add the insert to the queue
			_dbPledges.FacilityPledgeSubmissions.InsertOnSubmit(this);
			_dbPledges.SubmitChanges();
			_dbPledges.Dispose();
		}

		//public List<FacilityPledgeSubmission> GetFacilityPledgeSubmission()
		//{
		//    _dbPledges = new PledgeSubmissionsDataContext();
		//    List<FacilityPledgeSubmission> facPledgeSubmission = _dbPledges.FacilityPledgeSubmissions.ToList<FacilityPledgeSubmission>();
		//    _dbPledges.Dispose();
		//    return facPledgeSubmission;

		//}
	}
}
