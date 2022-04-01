
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.Data;

namespace ACR.Library.Radpac.Interfaces
{
	public interface IPledgeFormControl
	{
		bool GetPledgeObject(out Pledge pledge, PledgeTypeItem pledgeTypeItem);

		bool SendEmail(string addressTo, Pledge pledge);
       // bool SendEmailToUser(string addressTo, string Name,string Desc);
	}
}
