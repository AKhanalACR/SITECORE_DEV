using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ACR.controls.Overrides
{
	/// <summary>
	/// A custom class to add validation errors in code files without implementing a custom validator.
	/// </summary>
	public class CustomError : IValidator
	{
		private string _errorMessage;

		public CustomError(string errorMessage)
		{
			_errorMessage = errorMessage;
		}

		#region Implementation of IValidator

		public void Validate()
		{
		}

		public bool IsValid
		{
			get { return false; }
			set { }
		}

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set { }
		}

		#endregion
	}
}