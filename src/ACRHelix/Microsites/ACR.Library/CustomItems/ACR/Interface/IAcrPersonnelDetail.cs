using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface IAcrPersonnelDetail
	{
		/// <summary>
		/// Identifies this detail as a specific type (title, email, phone number).
		/// </summary>
		AcrPersonnelDetailType PersonnelDetailType { get; }

		/// <summary>
		/// The text for this detail.
		/// </summary>
		string PersonnelDetailText { get; }

		/// <summary>
		/// The url for this detail if it requires a link.
		/// </summary>
		string PersonnelDetailUrl { get; }
	}

	public enum AcrPersonnelDetailType
	{
		Title,
		FunctionalArea,
		Position,
		Location,
		Email,
		Phone,
		Address
	}
}