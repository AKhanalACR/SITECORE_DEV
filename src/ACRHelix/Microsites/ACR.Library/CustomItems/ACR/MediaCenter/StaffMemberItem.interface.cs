using System;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomItems.ACR.Interface.Wrappers;
using ACR.Library.Utils;
using System.Collections.Generic;

namespace ACR.Library.ACR.MediaCenter
{
	public partial class StaffMemberItem : IAcrPersonnel
	{
		#region IAcrPersonnel

		public string PersonnelName
		{
			get
			{
				//if we don't have a name, return an empty string
				if (Name == null)
				{
					return string.Empty;
				}

				//return our name
				return Name.Text;
			}
		}

		public string PersonnelImageUrl
		{
			get
			{
				//if we don't have an image then just return empty string
				if (Image == null)
				{
					return string.Empty;
				}

				//return our image sized properly
				return ImageUtil.GetScaledImageUrl(Image, 100, 0);
			}
		}

		public List<IAcrPersonnelDetail> ShortPersonnelDetails
		{
			get
			{
				//initialize our details list
				List<IAcrPersonnelDetail> details = new List<IAcrPersonnelDetail>();

				//for a staff members details we need to add title, functional area, phone number, and email
				if (Title != null)
				{
					AcrPersonnelDetailWrapper title = new AcrPersonnelDetailWrapper();
					title.PersonnelDetailType = AcrPersonnelDetailType.Title;
					title.PersonnelDetailText = Title.Text;
					details.Add(title);
				}

				if (FunctionalArea != null)
				{
					AcrPersonnelDetailWrapper functionalArea = new AcrPersonnelDetailWrapper();
					functionalArea.PersonnelDetailType = AcrPersonnelDetailType.FunctionalArea;
					functionalArea.PersonnelDetailText = FunctionalArea.Text;
					details.Add(functionalArea);
				}

				if (PhoneNumber != null)
				{
					AcrPersonnelDetailWrapper phoneNumber = new AcrPersonnelDetailWrapper();
					phoneNumber.PersonnelDetailType = AcrPersonnelDetailType.Phone;
					phoneNumber.PersonnelDetailText = PhoneNumber.Text;
					details.Add(phoneNumber);
				}

				if (Email != null)
				{
					AcrPersonnelDetailWrapper email = new AcrPersonnelDetailWrapper();
					email.PersonnelDetailType = AcrPersonnelDetailType.Email;
					email.PersonnelDetailText = Email.Text;
					email.PersonnelDetailUrl = "mailto:" + Email.Text;
					details.Add(email);
				}

				//return our details
				return details;
			}
		}

		public List<IAcrPersonnelDetail> PersonnelDetails
		{
			get
			{
				//this is the same as our short details
				return ShortPersonnelDetails;
			}
		}

		public string PersonnelBiography
		{
			get
			{
				//staff members do not currently have a biography
				return string.Empty;
			}
		}

		public string PersonnelUrl
		{
			get
			{
				//staff members do not currently have a page,
				return string.Empty;
			}
		}

		#endregion
	}
}