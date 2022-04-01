
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.Data;

namespace ACR.Library.ImageWisely.Interfaces
{
	public interface IPledgeFormControl
	{
		bool GetPledgeObject(out Pledge pledge, PledgeTypeItem pledgeTypeItem);

		bool SendEmail(string addressTo, Pledge pledge);
	}
}
