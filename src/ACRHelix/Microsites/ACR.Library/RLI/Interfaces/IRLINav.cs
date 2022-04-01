using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.RLI.Interfaces
{
	[FactoryInterface]
	public interface IRLINav
	{
		string NavTitle { get;}
		bool IncludeInNav { get;}
	}
}
