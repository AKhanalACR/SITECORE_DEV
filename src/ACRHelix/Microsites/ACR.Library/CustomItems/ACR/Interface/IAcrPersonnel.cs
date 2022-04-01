using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface IAcrPersonnel
	{
		/// <summary>
		/// The name of the person.
		/// </summary>
		string PersonnelName { get; }

		/// <summary>
		/// The url to an image of the person.
		/// </summary>
		string PersonnelImageUrl { get; }

		/// <summary>
		/// A subset of peronnel details.
		/// This can be used to display a short list of
		/// personnel details in a list.
		/// </summary>
		List<IAcrPersonnelDetail> ShortPersonnelDetails { get; }

		/// <summary>
		/// The details for this personnel.  This may include
		/// things like title, position, email, phone.
		/// </summary>
		List<IAcrPersonnelDetail> PersonnelDetails { get; }

		/// <summary>
		/// The biography of the person.
		/// </summary>
		string PersonnelBiography { get; }

		/// <summary>
		/// The url to this persons detail page.
		/// </summary>
		string PersonnelUrl { get; }
	}
}
